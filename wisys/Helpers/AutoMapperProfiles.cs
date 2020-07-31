﻿using AutoMapper;
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
			CreateMap<WarehouseEntity, WarehousePatchDTO>().ReverseMap();

			// Products
			CreateMap<ProductEntity, ProductPatchDTO>().ReverseMap();
			CreateMap<ProductDTO, ProductEntity>();
			CreateMap<ProductEntity, ProductCreationDTO>().ReverseMap();
			CreateMap<ProductEntity, ProductDTO>();
		}
	}
}