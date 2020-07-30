﻿using System;

namespace wisys.DTOs
{
	public class ProductCreationDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal BuyPrice { get; set; }
		public decimal SalePrice { get; set; }
		public DateTime Date { get; set; }
	}
}
