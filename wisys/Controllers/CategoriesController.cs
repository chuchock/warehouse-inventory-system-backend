using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.DTOs;
using wisys.Entities;
using wisys.Helpers;
using wisys.Services;

namespace wisys.Controllers
{

	[Route("api/categories")]
	[ApiController]
	[EnableCors("AllowAll")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoriesController : ControllerBase
	{
		private readonly AppDbContext dbContext;
		private readonly ICategoryRepository repository;
		private IMapper mapper;


		public CategoriesController(AppDbContext dbContext, ICategoryRepository repository,
									IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.dbContext = dbContext;
		}


		// api/categories
		[HttpGet]
		public async Task<ActionResult<List<CategoryDTO>>> Get([FromQuery] PaginationDTO pagination)
		{
			var queryable = dbContext.Categories
			.Where(c => c.Status == 1)
			.OrderBy(c => c.Name)
			.AsQueryable();

			await HttpContext.InsertPaginationParametersInResponse(queryable, pagination.RecordsPerPage);

			var categories = await queryable.Paginate(pagination).ToListAsync();

			return mapper.Map<List<CategoryDTO>>(categories);
		}


		// api/categories/count
		[HttpGet("count")]
		public async Task<ActionResult<int>> Count()
		{
			return await dbContext.Categories.Where(c => c.Status == 1).CountAsync();
		}


		// api/categories/{Id}
		[HttpGet("{id}", Name = "getCategory")]
		[ProducesResponseType(400)]// it is possible to return bad request
		[ProducesResponseType(typeof(CategoryEntity), 200)]
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
		public async Task<ActionResult> Post([FromBody] CategoryCreationDTO categoryCreationDTO)
		{
			try
			{
				var category = mapper.Map<CategoryEntity>(categoryCreationDTO);

				category.Status = 1;

				await repository.AddCategoryAsync(category);

				var categoryDTO = mapper.Map<CategoryDTO>(category);

				return new CreatedAtRouteResult("getCategory", new { id = category.CategoryId }, categoryDTO);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
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


		// api/categories/{id}
		[HttpPatch("{id}")]
		public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<CategoryPatchDTO> patchDocument)
		{
			if (patchDocument == null)
				return BadRequest();

			var entityFromDB = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

			if (entityFromDB == null)
				return NotFound();

			var entityDTO = mapper.Map<CategoryPatchDTO>(entityFromDB);

			patchDocument.ApplyTo(entityDTO, ModelState);

			var isValid = TryValidateModel(entityDTO);

			if (!isValid)
			{
				return BadRequest(ModelState);
			}

			mapper.Map(entityDTO, entityFromDB);

			await dbContext.SaveChangesAsync();

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
