using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace wisys.Controllers
{

	[Route("api/warehouses")]
	public class WarehousesController : ControllerBase
	{

		// api/warehouses
		[HttpGet]
		public ActionResult Get()
		{
			return NotFound();
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
