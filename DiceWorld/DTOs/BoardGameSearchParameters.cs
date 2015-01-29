using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWorld.DTOs
{
    public class BoardGameSearchParameters
    {
        /// <summary>
        /// Published year range
        /// </summary>
        public int? PublishedFrom { get; set; }
        public int? PublishedTo { get; set; }

        /// <summary>
        /// Keyword that should be found in the name
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Number of players range
        /// </summary>
        public int? MaxPlayers { get; set; }
        public int? MinPlayers { get; set; }
        /// <summary>
        /// Whether the range should be the exact range specified or
        /// if it should accomodate the set boundaries
        /// </summary>
        public bool ExactRange { get; set; }

        /// <summary>
        /// Min and max playing time
        /// </summary>
        public int? MaxPlayingTime { get; set; }
        public int? MinPlayingTime { get; set; }

        /// <summary>
        /// Whether the the game should have all the included filters (mechanic, category, ...)
        /// or if it can have only at least one included item
        /// </summary>
        public bool StrictInclude { get; set; }

        /// <summary>
        /// Mechanic ids to include or exclude from the search
        /// </summary>
        public int[] IncludeTags { get; set; }
        public int[] ExcludeTags { get; set; }

        /// <summary>
        /// Average range
        /// </summary>
        public double? MaxAverage { get; set; }
        public double? MinAverage { get; set; }

        /// <summary>
        /// Bayes average range
        /// </summary>
        public double? MinBayesRating { get; set; }
        public double? MaxBayesRating { get; set; }

        /// <summary>
        /// Average weight range
        /// </summary>
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }

        /// <summary>
        /// Page to get
        /// </summary>
        public uint? Page { get; set; }

        /// <summary>
        /// Number of results to return
        /// </summary>
        public uint? ItemsPerPage { get; set; }
    }
}