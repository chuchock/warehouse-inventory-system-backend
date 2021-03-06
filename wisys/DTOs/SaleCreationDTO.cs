﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.DTOs
{
	public class SaleCreationDTO
	{
		public int InventoryId { get; set; }
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; }
		public int WarehouseId { get; set; }
		public WarehouseEntity Warehouse { get; set; }
		public int SaleQuantity { get; set; }
	}
}
