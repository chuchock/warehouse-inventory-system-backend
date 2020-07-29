using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace wisys.Entities
{
	public class CategoryEntity
	{
		[Key]
		public int CategoryId { get; set; }
		public string Name {get; set;}
		public ICollection<ProductEntity> Products { get; set; }
	}
}
