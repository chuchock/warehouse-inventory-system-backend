using AutoMapper;
using wisys.DTOs;
using wisys.Entities;

namespace wisys.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			//Warehouses
			CreateMap<WarehouseCreationDTO, WarehouseEntity>();
			CreateMap<WarehouseEntity, WarehouseDTO>();

			// Products
			CreateMap<ProductEntity, ProductPatchDTO>().ReverseMap();
		}
	}
}
