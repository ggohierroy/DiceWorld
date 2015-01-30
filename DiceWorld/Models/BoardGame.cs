using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace DiceWorld.Models
{
    public class BoardGame
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Game Id on BGG
        /// </summary>
        public int BGGId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int YearPublished { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int PlayingTime { get; set; }

        public int MinAge { get; set; }

        public List<Tag> Tags { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime? DeletedDate { get; set; }

        public BoardGameStats BoardGameStats { get; set; }

        public decimal Price { get; set; }

        public int ImageId { get; set; }
    }
}
