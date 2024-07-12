using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;

namespace Ecommerce.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductDTO>()
                .ForMember(To => To.CategoryName, From => From.MapFrom(x => x.Category != null ? x.Category.Name : null));

            CreateMap<Products, CreateProductDTO>().ReverseMap();

            CreateMap<Orders, OrderDTO>().ReverseMap();
        }
    }
}
