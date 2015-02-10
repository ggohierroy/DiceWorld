using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class CartDTO
    {
        public IQueryable<Cart> Carts { get; set; }  
    }
}