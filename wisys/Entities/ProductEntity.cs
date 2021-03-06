﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class ProductEntity
	{
		[Key]
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal BuyPrice { get; set; }
		public decimal SalePrice { get; set; }
		public DateTime CreationDate { get; set; }
		public int Status { get; set; }
		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; }
	}
}
