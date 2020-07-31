using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.DTOs
{
	public class CategoryDTO
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public ICollection<ProductEntity> Products { get; set; }
	}
}
