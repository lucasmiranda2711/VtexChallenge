using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Application.Services.Users.Dto;

namespace Vtex.Challenge.Application.Services.Carts.Dto
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public UserResponseDto User { get; set; }
        public IList<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public IList<CartCupomDto> Cupoms { get; set; } = new List<CartCupomDto>();
        public decimal Price { get; set; }
        public decimal Discounts { get; set; }
        public decimal PriceWithDiscounts { get; set; }
        
    }
}