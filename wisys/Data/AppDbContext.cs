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

		public DbSet<WarehouseEntity> warehouses { get; set; }
		public DbSet<CategoryEntity> categories { get; set; }
		public DbSet<ProductEntity> products { get; set; }
		public DbSet<StorageEntity> storages { get; set; }
	}
}
