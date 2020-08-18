using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.DTOs
{
	public class InventoryCreationDTO
	{
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public int WarehouseId { get; set; }
	}
}
