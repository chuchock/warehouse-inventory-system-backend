using AutoMapper;
using wisys.DTOs;
using wisys.Entities;

namespace wisys.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			// Warehouses
			CreateMap<WarehouseCreationDTO, WarehouseEntity>();
			CreateMap<WarehouseEntity, WarehouseDTO>();
			CreateMap<WarehouseEntity, WarehousePatchDTO>().ReverseMap();

			// Categories
			CreateMap<CategoryEntity, CategoryPatchDTO>().ReverseMap();
			CreateMap<CategoryDTO, CategoryEntity>();
			CreateMap<CategoryEntity, CategoryCreationDTO>().ReverseMap();
			CreateMap<CategoryEntity, CategoryDTO>();

			// Products
			CreateMap<ProductEntity, ProductPatchDTO>().ReverseMap();
			CreateMap<ProductDTO, ProductEntity>();
			CreateMap<ProductEntity, ProductCreationDTO>().ReverseMap();
			CreateMap<ProductEntity, ProductDTO>();

			// Inventories
			CreateMap<InventoryEntity, InventoryDTO>();
			CreateMap<InventoryCreationDTO, InventoryEntity>();
			CreateMap<InventoryEntity, ProductStockDTO>();
		}
	}
}
