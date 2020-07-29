using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wisys.Entities;
using wisys.Services;

namespace wisys.Controllers
{

	[Route("api/warehouses")]
	[ApiController]
	public class WarehousesController : ControllerBase
	{
		private readonly IWarehouseRepository repository;

		public WarehousesController(IWarehouseRepository repository)
		{
			this.repository = repository;
		}

		// api/warehouses
		[HttpGet]
		public async Task<ActionResult<List<WarehouseEntity>>> Get()
		{
			var warehouses = await repository.GetAllWarehousesAsync();

			return warehouses;
		}

		// api/warehouses/{Id}
		[HttpGet("{id}")]
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
		public async Task<ActionResult> Post(WarehouseEntity warehouse)
		{
			await repository.AddWarehouseAsync(warehouse);

			return NoContent();
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
