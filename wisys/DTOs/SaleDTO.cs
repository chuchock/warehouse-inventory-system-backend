using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wisys.Entities;

namespace wisys.DTOs
{
	public class SaleDTO
	{
		public int SaleId { get; set; }
		public DateTime SaleDate { get; set; }
		public int Status { get; set; }
		public decimal Total { get; set; }
		public ICollection<SaleProductDTO> SaleProducts { get; set; }
	}
}
