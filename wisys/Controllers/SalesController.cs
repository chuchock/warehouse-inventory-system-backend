using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.DTOs;
using wisys.Entities;
using wisys.Helpers;

namespace wisys.Controllers
{
	[Route("api/sales")]
	[ApiController]
	[EnableCors("AllowAll")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class SalesController : ControllerBase
	{
		private readonly AppDbContext dbContext;
		private readonly IMapper mapper;


		public SalesController(AppDbContext dbContext, IMapper mapper)
		{
			this.mapper = mapper;
			this.dbContext = dbContext;
		}


		// api/sales
		[HttpGet]
		public async Task<ActionResult<List<SaleDTO>>> Get([FromQuery] PaginationDTO pagination)
		{
			var queryable = dbContext.Sales.Where(s => s.Status == 1)
			.Include(s => s.SaleProducts).ThenInclude(p => p.Product)
			.Include(s => s.SaleProducts).ThenInclude(p => p.Warehouse)
			.OrderByDescending(s => s.SaleDate)
			.AsQueryable();

			await HttpContext.InsertPaginationParametersInResponse(queryable, pagination.RecordsPerPage);

			var sales = await queryable.Paginate(pagination).ToListAsync();

			var salesDTO = mapper.Map<List<SaleDTO>>(sales);

			// Calculate the total of the sale
			foreach (var sale in salesDTO)
			{	
				decimal total = 0;
				foreach (var product in sale.SaleProducts)
				{
					total += (product.SalePrice * product.Quantity);
				}
				sale.Total = total;
				sale.formatedDate = sale.SaleDate.ToString("dd-MM-yyyy HH:mm:ss");
			}

			return salesDTO;
		}


		// api/sales/count
		[HttpGet("count")]
		public async Task<ActionResult<int>> Count()
		{
			return await dbContext.SaleProduct.CountAsync();
		}


		// api/sales/{Id}
		[HttpGet("{id}", Name = "getSale")]
		public async Task<ActionResult<SaleDTO>> Get(int id)
		{
			var sale = await dbContext.Sales.Where(s => s.SaleId == id).FirstOrDefaultAsync();

			if (sale == null)
				return NotFound();

			return mapper.Map<SaleDTO>(sale);
		}


		// api/sales
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ICollection<SaleCreationDTO> saleCreationDTO)
		{
			if (saleCreationDTO.Count > 0)
			{
				using (var transaction = dbContext.Database.BeginTransaction())
				{
					try
					{
						// Add sale
						var sale = new SaleEntity
						{
							SaleDate = DateTime.UtcNow,
							Status = 1
						};
						await dbContext.Sales.AddAsync(sale);
						await dbContext.SaveChangesAsync();
						int saleId = sale.SaleId;

						//Add Sale products
						foreach (var product in saleCreationDTO)
						{
							var saleProduct = mapper.Map<SaleProductCreationDTO>(product);
							saleProduct.SaleId = saleId;
							saleProduct.ProductId = product.Product.ProductId;
							saleProduct.WarehouseId = product.Warehouse.WarehouseId;
							saleProduct.SalePrice = product.Product.SalePrice;
							saleProduct.Quantity = product.SaleQuantity;

							var newSaleProduct = mapper.Map<SaleProductEntity>(saleProduct);
							await dbContext.SaleProduct.AddAsync(newSaleProduct);

							// Update Inventory quantities
							var inventory = await dbContext.Inventories.FirstAsync(a => a.InventoryId == product.InventoryId);
							inventory.Quantity = inventory.Quantity - product.SaleQuantity;
						}

						await dbContext.SaveChangesAsync();

						// Commit transaction
						transaction.Commit();

						var saleDTO = mapper.Map<SaleDTO>(sale);

						return new CreatedAtRouteResult("getSale", new { id = sale.SaleId }, saleDTO);
					}
					catch (Exception ex)
					{
						return StatusCode(500);
					}
				}
			}
			else
			{
				return BadRequest(new { message = "Sale info is empty" });
			}
		}
	}
}

