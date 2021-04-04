using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Application.Services.Users.Dto;

namespace Vtex.Challenge.Application.Services.Carts.Dto
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public UserRequestDto User { get; set; }
        public IList<CartItemDto> items { get; set; } = new List<CartItemDto>();

        public decimal GetTotalCartPrice()
        {
            return items.Sum(item => item.GetTotalPrice());
        }
    }
}