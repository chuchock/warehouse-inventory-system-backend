using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace wisys.Controllers
{
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		// api/products
		[HttpGet]
		public ActionResult Get()
		{
			return NotFound();
		}

		// api/products/{Id}
		[HttpGet("{Id}")]
		public ActionResult Get(int Id)
		{
			return NotFound();
		}

		// api/products
		[HttpPost]
		public ActionResult Post()
		{
			return NotFound();
		}

		// api/products
		[HttpPut]
		public ActionResult Put()
		{
			return NotFound();
		}

		// api/products/{Id}
		[HttpDelete]
		public ActionResult Delete()
		{
			return NotFound();
		}
	}
}
