using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wisys.Entities;
using wisys.Services;

namespace wisys.Controllers
{
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository repository;

		public ProductsController(IProductRepository repository)
		{
			this.repository = repository;
		}

		// api/products
		[HttpGet]
		public async Task<ActionResult<List<ProductEntity>>> Get()
		{
			var products = await repository.GetAllProductsAsync();

			return products;
		}

		// api/products/{Id}
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductEntity>> Get(int id)
		{
			var product = await repository.GetProductByIdAsync(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;
		}

		// api/products
		[HttpPost]
		public async Task<ActionResult> Post(ProductEntity product)
		{
			await repository.AddProductAsync(product);

			return NoContent();
		}

		// api/products
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, ProductEntity product)
		{
			var exists = await repository.GetProductByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.UpdateProductAsync(id, product);

			return NoContent();
		}

		// api/products/{Id}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var exists = await repository.GetProductByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.DeleteProductAsync(id);

			return NoContent();
		}
	}
}
