using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class SaleProductEntity
	{
		[Key]
		public int SaleProductId { get; set; }
		public int Quantity { get; set; }
		public decimal SalePrice { get; set; }
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; }
		public int WarehouseId { get; set; }
		public WarehouseEntity Warehouse { get; set; }
		public int SaleId { get; set; }
		public SaleEntity Sale { get; set; }
	}
}
