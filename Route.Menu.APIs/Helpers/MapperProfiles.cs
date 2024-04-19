using AutoMapper;
using Route.Menu.APIs.DTOs;
using Route.Menu.Core.Enities;

namespace Route.Menu.APIs.Helpers
{
	public class MapperProfiles : Profile
	{

        public MapperProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name))
				.ForMember(P => P.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());


        }
    }
}
