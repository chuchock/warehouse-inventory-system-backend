using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace wisys.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class DefaultController : ControllerBase
	{
		[Route("/")]
		[Route("/swagger")]
		[Route("/doc")]
		public RedirectResult Index()
		{
			return new RedirectResult("~/swagger");
		}
	}
}
