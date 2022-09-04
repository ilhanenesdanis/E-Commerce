﻿using API.Dtos;
using AutoMapper;
using Core.DbModels;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x=>x.ProductBrands,o=>o.MapFrom(s=>s.ProductBrands.Name))
                .ForMember(x=>x.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(x=>x.PictureUrl,o=>o.MapFrom<ProductUrlResolver>())
                .ReverseMap();
        }
    }
}
