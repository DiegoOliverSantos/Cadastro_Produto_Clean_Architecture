using AutoMapper;
using CleanArchMVC.Application.Commands;
using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, CreateProductCommand>();
            CreateMap<ProductDTO, UpdateProductCommand>();
            CreateMap<CategoryDTO, CreateCategoryCommand>();
            CreateMap<CategoryDTO, UpdateCategoryCommand>();
        }
    }
}
