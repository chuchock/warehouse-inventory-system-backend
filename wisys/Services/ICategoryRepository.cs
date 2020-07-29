using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.Services
{
	public interface ICategoryRepository
	{
		Task<List<CategoryEntity>> GetAllCategoriesAsync();
		Task<CategoryEntity> GetCategoryByIdAsync(int id);
		Task AddCategoryAsync(CategoryEntity category);
		Task UpdateCategoryAsync(int id, CategoryEntity category);
		Task DeleteCategoryAsync(int Id);
	}
}
