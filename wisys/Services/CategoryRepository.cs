using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.Entities;

namespace wisys.Services
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _dbContext;

		public CategoryRepository(AppDbContext context)
		{
			_dbContext = context;
		}

		public async Task AddCategoryAsync(CategoryEntity category)
		{
			await _dbContext.Categories.AddAsync(category);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteCategoryAsync(int id)
		{

			_dbContext.Categories.Remove(new CategoryEntity() { CategoryId = id });
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
		{
			return await _dbContext.Categories.ToListAsync();
		}

		public async Task<CategoryEntity> GetCategoryByIdAsync(int id)
		{
			return await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
		}

		public async Task UpdateCategoryAsync(int id, CategoryEntity category)
		{
			category.CategoryId = id;
			_dbContext.Entry(category).State = EntityState.Modified;

			await _dbContext.SaveChangesAsync();
		}
	}
}
