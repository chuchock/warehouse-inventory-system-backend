using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.DTOs
{
	public class SaleProductCreationDTO
	{
		public int Quantity { get; set; }
		public decimal SalePrice { get; set; }
		public int ProductId { get; set; }
		public int WarehouseId { get; set; }
		public int SaleId { get; set; }
	}
}
