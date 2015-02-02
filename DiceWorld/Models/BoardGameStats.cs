using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DiceWorld.Models
{
    public class BoardGameStats
    {
        [Key, ForeignKey("BoardGame")]
        public int Id { get; set; }

        /// <summary>
        /// Number of users that have rated the game
        /// </summary>
        public int NumberOfUsers { get; set; }

        /// <summary>
        /// Average rating given by users (1 worst to 10 best)
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// Weighted average based on number of voters
        /// </summary>
        public double BayesianRating { get; set; }

        /// <summary>
        /// Heaviness of the game (1 lightest to 5 heaviest)
        /// </summary>
        public double AverageWeight { get; set; }

        /// <summary>
        /// Rank of the game based on its stats
        /// </summary>
        public int Rank { get; set; }

        //public int BoardGameId { get; set; }

        /// <summary>
        /// Board game associated with theses stats
        /// </summary>
        [JsonIgnore]
        public BoardGame BoardGame { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime? DeletedDate { get; set; }

        public int Hotness { get; set; }
    }
}
