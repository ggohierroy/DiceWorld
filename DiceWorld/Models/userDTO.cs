using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.Models
{
    public class userDTO
    {
        public int Id { get; set; }

        public int? Cart { get; set; }

        public List<int> Orders { get; set; } 
    }
}