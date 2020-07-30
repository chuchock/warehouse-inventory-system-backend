using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using wisys.DTOs;
using wisys.Entities;
using wisys.Services;

namespace wisys.Controllers
{

	[Route("api/warehouses")]
	[ApiController]
	public class WarehousesController : ControllerBase
	{
		private readonly IWarehouseRepository repository;
		private IMapper mapper;

		public WarehousesController(IWarehouseRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		// api/warehouses
		[HttpGet]
		public async Task<ActionResult<List<WarehouseEntity>>> Get()
		{
			var warehouses = await repository.GetAllWarehousesAsync();

			return warehouses;
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
