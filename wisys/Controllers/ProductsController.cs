using System.Collections.Generic;
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
	[Route("api/products")]
	[ApiController]
	[EnableCors("AllowAll")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ProductsController : ControllerBase
	{
		private readonly AppDbContext dbContext;
		private readonly IProductRepository repository;
		private readonly IMapper mapper;


		public ProductsController(AppDbContext dbContext, IMapper mapper, IProductRepository repository)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.dbContext = dbContext;
		}


		// api/products
		[HttpGet]
		public async Task<ActionResult<List<ProductEntity>>> Get([FromQuery] PaginationDTO pagination)
		{
			var queryable = dbContext.Products.AsQueryable();
			await HttpContext.InsertPaginationParametersInResponse(queryable, pagination.RecordsPerPage);

			var products = await queryable.Paginate(pagination).ToListAsync();

			//var products = await repository.GetAllProductsAsync();

			return products;
		}


		// api/products/count
		[HttpGet("count")]
		public async Task<ActionResult<int>> Count()
		{
			return await dbContext.Products.CountAsync();
		}


		// api/products/{Id}
		[HttpGet("{id}", Name = "getProduct")]
		public async Task<ActionResult<ProductDTO>> Get(int id)
		{
			var product = await repository.GetProductByIdAsync(id);

			if (product == null)
				return NotFound();

			return mapper.Map<ProductDTO>(product);
		}


		// api/products
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ProductCreationDTO productCreationDTO)
		{
			var product = mapper.Map<ProductEntity>(productCreationDTO);

			await repository.AddProductAsync(product);

			var productDTO = mapper.Map<ProductDTO>(product);

			return new CreatedAtRouteResult("getProduct", new { id = product.ProductId }, productDTO);
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


		[HttpPatch("{id}")]
		public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ProductPatchDTO> patchDocument)
		{
			if (patchDocument == null)
				return BadRequest();

			var entityFromDB = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

			if (entityFromDB == null)
				return NotFound();

			var entityDTO = mapper.Map<ProductPatchDTO>(entityFromDB);

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
