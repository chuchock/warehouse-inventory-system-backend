using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.Services
{
	public interface IWarehouseRepository
	{
		Task<List<WarehouseEntity>> GetAllWarehousesAsync();
		Task<WarehouseEntity> GetWarehouseByIdAsync(int Id);
		Task AddWarehouseAsync(WarehouseEntity warehouse);
		Task UpdateWarehouseAsync(WarehouseEntity warehouse);
		Task DeleteWarehouseAsync(int Id);
	}
}
