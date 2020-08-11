using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class InventoryEntity
	{
		[Key]
		public int InventoryId { get; set; }
		public int Quantity { get; set; }
		public int Status { get; set; }
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; }
		public int WarehouseId { get; set; }
		public WarehouseEntity Warehouse { get; set; }
	}
}
