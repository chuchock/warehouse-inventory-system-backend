using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.DTOs
{
	public class InventoryDTO
	{
		public int InventoryId { get; set; }
		public int Quantity { get; set; }
		public ProductDTO Product { get; set; }
		public WarehouseDTO Warehouse { get; set; }
	}
}
