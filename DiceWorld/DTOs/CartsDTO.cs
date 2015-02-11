using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class CartsDTO
    {
        public IQueryable<CartDTO> Carts { get; set; }

        public List<CartItem> CartItems { get; set; } 
    }
}