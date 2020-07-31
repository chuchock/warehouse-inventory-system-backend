using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.DTOs
{
	public class CategoryPatchDTO
	{
		public string Name { get; set; }
		public ICollection<CategoryEntity> Products { get; set; }
	}
}
