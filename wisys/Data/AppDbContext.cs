﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wisys.Entities;

namespace wisys.Data
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<WarehouseEntity> Warehouses { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<SaleEntity> Sales { get; set; }
		public DbSet<SaleProductEntity> SaleProduct { get; set; }
		public DbSet<InventoryEntity> Inventories { get; set; }
	}
}
