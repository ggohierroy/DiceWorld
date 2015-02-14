using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.DTOs
{
    public class CartContainerDTO
    {
        public CartDTO Cart { get; set; }

        public List<CartItemDTO> CartItems { get; set; }

        public List<BoardGameDTO> BoardGames { get; set; } 
    }
}