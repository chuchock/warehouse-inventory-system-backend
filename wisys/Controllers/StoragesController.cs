using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace wisys.Controllers
{
	[Route("api/storages")]
	public class StoragesController : ControllerBase
	{
		// api/storages
		[HttpGet]
		public ActionResult Get()
		{
			return NotFound();
		}

		// api/storages/{Id}
		[HttpGet("{Id}")]
		public ActionResult Get(int Id)
		{
			return NotFound();
		}

		// api/storages
		[HttpPost]
		public ActionResult Post()
		{
			return NotFound();
		}

		// api/storages
		[HttpPut]
		public ActionResult Put()
		{
			return NotFound();
		}

		// api/storages/{Id}
		[HttpDelete]
		public ActionResult Delete()
		{
			return NotFound();
		}
	}
}
