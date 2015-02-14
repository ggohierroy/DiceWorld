using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Cart { get; set; }

        public List<int> Orders { get; set; }

        public bool Anonymous { get; set; }
    }
}