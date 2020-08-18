using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
			
			var inventory = mapper.Map<InventoryEntity>(inventoryCreationDTO);
			inventory.Status = 1;

			await dbContext.Inventories.AddAsync(inventory);
			await dbContext.SaveChangesAsync();

			var inventoryDTO = mapper.Map<InventoryDTO>(inventory);

			return new CreatedAtRouteResult("getInventory", new { id = inventory.InventoryId }, inventoryDTO);
		}
	}
}
