using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class CategoryEntity
	{
		public int CategoryId { get; set; }
		public string Name {get; set;}
		public ICollection<ProductEntity> Products { get; set; }
	}
}
