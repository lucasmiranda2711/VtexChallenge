using System;
using System.ComponentModel.DataAnnotations;

namespace Vtex.Challenge.Application.Services.Items
{
    public class ItemRequestDto
    {
        [Required]
        public Guid CartId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public int ItemQuantity { get; set; }
    }
}
