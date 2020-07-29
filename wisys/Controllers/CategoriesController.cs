using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wisys.Entities;
using wisys.Services;

namespace wisys.Controllers
{

	[Route("api/categories")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository repository;

		public CategoriesController(ICategoryRepository repository)
		{
			this.repository = repository;
		}

		// api/categories
		[HttpGet]
		public async Task<ActionResult<List<CategoryEntity>>> Get()
		{
			var categories = await repository.GetAllCategoriesAsync();

			return categories;
		}

		// api/categories/{Id}
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryEntity>> Get(int id)
		{
			var category = await repository.GetCategoryByIdAsync(id);

			if (category == null)
			{
				return NotFound();
			}

			return category;
		}

		// api/categories
		[HttpPost]
		public async Task<ActionResult> Post(CategoryEntity category)
		{
			await repository.AddCategoryAsync(category);

			return NoContent();
		}

		// api/categories
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, CategoryEntity category)
		{
			var exists = await repository.GetCategoryByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.UpdateCategoryAsync(id, category);

			return NoContent();
		}

		// api/categories/{Id}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var exists = await repository.GetCategoryByIdAsync(id);

			if (exists == null)
				return NotFound();

			await repository.DeleteCategoryAsync(id);

			return NoContent();
		}
	}
}
