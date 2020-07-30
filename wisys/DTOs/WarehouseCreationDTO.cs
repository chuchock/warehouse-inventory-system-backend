using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wisys.DTOs
{
	public class WarehouseCreationDTO
	{
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
		public string Address { get; set; }
	}
}
