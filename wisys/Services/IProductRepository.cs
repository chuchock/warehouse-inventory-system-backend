﻿using System.Collections.Generic;
using System.Threading.Tasks;
using wisys.DTOs;
using wisys.Entities;

namespace wisys.Services
{
	public interface IProductRepository
	{
		Task<List<ProductEntity>> GetAllProductsAsync();
		Task<ProductEntity> GetProductByIdAsync(int id);
		Task AddProductAsync(ProductEntity product);
		Task UpdateProductAsync(int id, ProductEntity product);
		Task DeleteProductAsync(int Id);
	}
}
