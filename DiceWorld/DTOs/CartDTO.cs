using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<int> CartItems { get; set; }  
    }
}