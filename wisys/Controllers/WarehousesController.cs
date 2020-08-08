using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.DTOs;
using wisys.Entities;
using wisys.Helpers;
using wisys.Services;

namespace wisys.Controllers
{

	[Route("api/warehouses")]
	[ApiController]
	//[EnableCors(PolicyName = "AllowAll")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class WarehousesController : ControllerBase
	{
		private readonly AppDbContext dbContext;
		private readonly IWarehouseRepository repository;
		private IMapper mapper;


		public WarehousesController(AppDbContext dbContext, IWarehouseRepository repository,
									IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.dbContext = dbContext;
		}


		// api/warehouses
		[HttpGet]
		public async Task<ActionResult<List<WarehouseDTO>>> Get([FromQuery] PaginationDTO pagination)
		{
			var queryable = dbContext.Warehouses.AsQueryable();
			await HttpContext.InsertPaginationParametersInResponse(queryable, pagination.RecordsPerPage);

			var warehouses = await queryable.Paginate(pagination).ToListAsync();

			return mapper.Map<List<WarehouseDTO>>(warehouses);
		}


		// api/warehouses/count
		[HttpGet("count")]
		public async Task<ActionResult<int>> Count()
		{
			return await dbContext.Warehouses.CountAsync();
		}


		// api/warehouses/{Id}
		[HttpGet("{id}", Name = "getWarehouse")]
		public async Task<ActionResult<WarehouseEntity>> Get(int id)
		{
			var warehouse = await repository.GetWarehouseByIdAsync(id);

			if (warehouse == null)
			{
				return NotFound();
			}

			return warehouse;
		}


		// api/warehouses
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] WarehouseCreationDTO warehouseCreationDTO)
		{
			var warehouse = mapper.Map<WarehouseEntity>(warehouseCreationDTO);

			await repository.AddWarehouseAsync(warehouse);

			var warehouseDTO = mapper.Map<WarehouseDTO>(warehouse);

			return new CreatedAtRouteResult("getWarehouse", new { id = warehouse.WarehouseId }, warehouseDTO);
		}


		// api/warehouses
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, WarehouseEntity warehouse)
		{
			var exists = await repository.GetWarehouseByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.UpdateWarehouseAsync(id, warehouse);

			return NoContent();
		}

		
		// api/warehouses/{id}
		[HttpPatch("{id}")]
		public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<WarehousePatchDTO> patchDocument)
		{
			if (patchDocument == null)
				return BadRequest();

			var entityFromDB = await dbContext.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == id);

			if (entityFromDB == null)
				return NotFound();

			var entityDTO = mapper.Map<WarehousePatchDTO>(entityFromDB);

			patchDocument.ApplyTo(entityDTO, ModelState);

			var isValid = TryValidateModel(entityDTO);

			if (!isValid)
			{
				return BadRequest(ModelState);
			}

			mapper.Map(entityDTO, entityFromDB);

			await dbContext.SaveChangesAsync();

			return NoContent();
		}


		// api/warehouses/{Id}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var exists = await repository.GetWarehouseByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.DeleteWarehouseAsync(id);

			return NoContent();
		}
	}
}
