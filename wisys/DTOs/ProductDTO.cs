using System;
using wisys.Entities;

namespace wisys.DTOs
{
	public class ProductDTO
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal BuyPrice { get; set; }
		public decimal SalePrice { get; set; }
		public DateTime Date { get; set; }
		public string CategoryId { get; set; }
		public CategoryEntity Category { get; set; }
	}
}
