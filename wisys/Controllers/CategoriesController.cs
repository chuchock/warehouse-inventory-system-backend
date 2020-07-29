using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace wisys.Controllers
{

	[Route("api/categories")]
	public class CategoriesController : ControllerBase
	{
		// api/products
		[HttpGet]
		public ActionResult Get()
		{
			return NotFound();
		}

		// api/categories/{Id}
		[HttpGet("{Id}")]
		public ActionResult Get(int Id)
		{
			return NotFound();
		}

		// api/categories
		[HttpPost]
		public ActionResult Post()
		{
			return NotFound();
		}

		// api/categories
		[HttpPut]
		public ActionResult Put()
		{
			return NotFound();
		}

		// api/categories/{Id}
		[HttpDelete]
		public ActionResult Delete()
		{
			return NotFound();
		}
	}
}
