using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.DTOs;
using wisys.Entities;
using wisys.Helpers;
using wisys.Services;

namespace wisys.Controllers
{
	[Route("api/inventories")]
	[ApiController]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class InventoriesController : ControllerBase
	{
		private readonly AppDbContext dbContext;
		private readonly IMapper mapper;


		public InventoriesController(AppDbContext dbContext, IMapper mapper, IProductRepository repository)
		{
			this.mapper = mapper;
			this.dbContext = dbContext;
		}


		// api/inventories
		[HttpGet]
		public async Task<ActionResult<List<InventoryEntity>>> Get([FromQuery] PaginationDTO pagination)
		{
			var queryable = dbContext.Inventories.Where(s => s.Status == 1)
						.Include(s => s.Warehouse.Name)
						.Include(s => s.Product.Name)
						.AsQueryable();

			await HttpContext.InsertPaginationParametersInResponse(queryable, pagination.RecordsPerPage);

			var inventories = await queryable.Paginate(pagination).ToListAsync();

			return inventories;
		}


		// api/inventories/{Id}
		[HttpGet("{id}", Name = "getInventory")]
		public async Task<ActionResult<InventoryDTO>> Get(int id)
		{
			var inventory = await dbContext.Inventories.Where(s => s.InventoryId == id).FirstOrDefaultAsync();

			if (inventory == null)
				return NotFound();

			return mapper.Map<InventoryDTO>(inventory);
		}


		// api/inventories
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] InventoryCreationDTO inventoryCreationDTO)
		{
			try
			{
				var inventory = mapper.Map<InventoryEntity>(inventoryCreationDTO);

				// Check if inventory already exists in table
				var inventoryInTable = dbContext.Inventories
					.Where(i => i.ProductId == inventory.ProductId && i.WarehouseId == inventory.WarehouseId).FirstOrDefault();

				if (inventoryInTable != null)
				{
					inventoryInTable.Quantity += inventory.Quantity;
				}
				else
				{
					inventory.Status = 1;

					await dbContext.Inventories.AddAsync(inventory);
				}

				await dbContext.SaveChangesAsync();

				var inventoryDTO = mapper.Map<InventoryDTO>(inventory);

				return new CreatedAtRouteResult("getInventory", new { id = inventory.InventoryId }, inventoryDTO);

			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}
		}


		// api/inventories/{id}/product/{Name}
		[HttpGet("{id:int?}/product/{name}", Name = "getProductStock")]
		public async Task<ActionResult<List<ProductStockDTO>>> Get(int? id, string name)
		{
			try
			{
				var stock = await dbContext.Inventories.Where(i => i.Quantity > 0 && i.Product.Name.ToLower().Contains(name.ToLower()))
							.Include(p => p.Product)
							.Include(w => w.Warehouse).ToListAsync();

				if (stock == null)
					return NotFound();

				return mapper.Map<List<ProductStockDTO>>(stock);
			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}
		}
	}
}
