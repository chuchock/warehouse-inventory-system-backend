using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class SaleEntity
	{
		[Key]
		public int SaleId { get; set; }
		public int Quantity { get; set; }
		public DateTime SaleDate { get; set; }
		public int Status { get; set; }
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; }
	}
}
