using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public int Cart { get; set; }

        public int BoardGame { get; set; }

        public int Quantity { get; set; }
    }
}