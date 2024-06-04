using AutoMapper;
using WAD._00013622.Dtos;
using WAD._00013622.Models;

namespace WAD._00013622.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Order Mappings
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
        }
    }
}
