using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.Entities;

namespace wisys.Services
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _dbContext;

		public ProductRepository(AppDbContext context)
		{
			_dbContext = context;
		}

		public async Task AddProductAsync(ProductEntity product)
		{
			product.CreationDate = DateTime.Now;
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int id)
		{

			_dbContext.Products.Remove(new ProductEntity() { ProductId = id });
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<ProductEntity>> GetAllProductsAsync()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<ProductEntity> GetProductByIdAsync(int id)
		{
			return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
		}

		public async Task UpdateProductAsync(int id, ProductEntity product)
		{
			product.ProductId = id;
			_dbContext.Entry(product).State = EntityState.Modified;

			await _dbContext.SaveChangesAsync();
		}
	}
}
