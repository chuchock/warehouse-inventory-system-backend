using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class StorageEntity
	{
		public string StorageId { get; set; }
		public DateTime LastUpdate { get; set; }
		public int PartialQuantity { get; set; }
		public string ProductId { get; set; }
		public ProductEntity Product { get; set; }
		public string WarehouseId { get; set; }
		public WarehouseEntity Warehouse { get; set; }
	}
}
