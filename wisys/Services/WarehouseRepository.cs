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

		public void AddWarehouseAsync(WarehouseEntity warehouse)
		{
			throw new NotImplementedException();
		}

		public void DeleteWarehouseAsync(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<WarehouseEntity>> GetAllWarehousesAsync()
		{
			return await _dbContext.Warehouses.ToListAsync();
		}

		public WarehouseEntity GetWarehouseByIdAsync(int Id)
		{
			throw new NotImplementedException();
		}

		public void UpdateWarehouseAsync(WarehouseEntity warehouse)
		{
			throw new NotImplementedException();
		}
	}
}
