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
		[HttpGet("{Id}")]
		public ActionResult Get(int Id)
		{
			return NotFound();
		}

		// api/warehouses
		[HttpPost]
		public ActionResult Post()
		{
			return NotFound();
		}

		// api/warehouses
		[HttpPut]
		public ActionResult Put()
		{
			return NotFound();
		}

		// api/warehouses/{Id}
		[HttpDelete]
		public ActionResult Delete()
		{
			return NotFound();
		}
	}
}
