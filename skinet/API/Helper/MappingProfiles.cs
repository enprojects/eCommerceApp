using API.Response;
using AutoMapper;
using AutoMapper.Configuration;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Policy;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;



        public MappingProfiles()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                // .ForMember(d => d.PictureUrl, PropertyBuilder);
                .ForMember(d => d.PictureUrl, o=>o.MapFrom<UrlResolver>());

        }


        private void PropertyBuilder(IMemberConfigurationExpression<Product, ProductResponse, string> obj)
        {

            var url = "https://localhost:44306/content";
            obj.MapFrom(s => s.PictureUrl);
            obj.AddTransform(x => string.IsNullOrEmpty(x) ? "No url found.." : $"{url}/{x}");
        }
    }
}
