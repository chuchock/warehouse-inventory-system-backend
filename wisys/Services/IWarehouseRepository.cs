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
		WarehouseEntity GetWarehouseByIdAsync(int Id);
		void AddWarehouseAsync(WarehouseEntity warehouse);
		void UpdateWarehouseAsync(WarehouseEntity warehouse);
		void DeleteWarehouseAsync(int Id);
	}
}
