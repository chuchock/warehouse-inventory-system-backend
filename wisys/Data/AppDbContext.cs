using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wisys.Entities;

namespace wisys.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<WarehouseEntity> Warehouses { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<StorageEntity> Storages { get; set; }
	}
}
