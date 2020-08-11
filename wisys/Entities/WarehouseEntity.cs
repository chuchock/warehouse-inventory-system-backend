using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class WarehouseEntity
	{
		[Key]
		public int WarehouseId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public int Status { get; set; }
		public ICollection<InventoryEntity> Inventories { get; set; }
	}
}
