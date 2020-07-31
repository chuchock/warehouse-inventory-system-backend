using System.ComponentModel.DataAnnotations;

namespace wisys.DTOs
{
	public class CategoryCreationDTO
	{
		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
	}
}
