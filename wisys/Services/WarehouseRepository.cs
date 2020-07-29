using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wisys.Data;
using wisys.Entities;

namespace wisys.Services
{
	public class WarehouseRepository : IWarehouseRepository
	{
		private readonly AppDbContext _dbContext;

		public WarehouseRepository(AppDbContext context)
		{
			_dbContext = context;
		}

		public async Task AddWarehouseAsync(WarehouseEntity warehouse)
		{
			await _dbContext.Warehouses.AddAsync(warehouse);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteWarehouseAsync(int id)
		{

			_dbContext.Warehouses.Remove(new WarehouseEntity() { WarehouseId = id });
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<WarehouseEntity>> GetAllWarehousesAsync()
		{
			return await _dbContext.Warehouses.ToListAsync();
		}

		public async Task<WarehouseEntity> GetWarehouseByIdAsync(int id)
		{
			return await _dbContext.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == id);
		}

		public async Task UpdateWarehouseAsync(int id, WarehouseEntity warehouse)
		{
			warehouse.WarehouseId = id;
			_dbContext.Entry(warehouse).State = EntityState.Modified;

			await _dbContext.SaveChangesAsync();
		}
	}
}
