using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Vtex.Challenge.Application.Services.Carts.Dto;
using Vtex.Challenge.Application.Services.Users.Dto;
using Vtex.Challenge.Domain.Model.Auth;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Web.Mappings
{
    public class AutomapperConfig : Profile
    {
        public static void RegisterMapping(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartDto>()
                .ForMember(d=> d.Discounts, s=> s.MapFrom(x=> x.GetTotalDiscount()))
                .ForMember(d => d.Price, s => s.MapFrom(x => x.GetTotalCartPrice()))
                .ForMember(d => d.PriceWithDiscounts, s => s.MapFrom(x => x.GetTotalCartPriceWithDiscounts()));
                cfg.CreateMap<User, UserResponseDto>();
                cfg.CreateMap<CartItem, CartItemDto>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Item.Name))
                .ForMember(d => d.Price, s => s.MapFrom(x => x.Item.Price))
                .ForMember(d => d.Quantity, s => s.MapFrom(x => x.ItemQuantity));
                cfg.CreateMap<CartCupom, CartCupomDto>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Cupom.Name))
                .ForMember(d => d.DiscountValue, s => s.MapFrom(x => x.Cupom.DiscountValue));
            });

            IMapper mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
