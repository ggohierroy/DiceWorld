using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiceWorld.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Reference { get; set; }

        public double Tax { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal Total { get; set; }

        public List<CartItem> Details { get; set; } 
    }
}