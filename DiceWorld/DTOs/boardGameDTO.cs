using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class BoardGameDTO
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

        public List<int> TagDefinitions { get; set; }

        public int BoardGameStat { get; set; }

        public decimal Price { get; set; }

        public int ImageId { get; set; }
    }
}