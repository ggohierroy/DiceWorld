using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DiceWorld.Models
{
    public class Tag
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int BoardGameId { get; set; }

        [ForeignKey("BoardGameId")]
        [JsonIgnore]
        public BoardGame BoardGame { get; set; }

        [JsonIgnore]
        public int TagDefinitionId { get; set; }

        [ForeignKey("TagDefinitionId")]
        public TagDefinition TagDefinition { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime? DeletedDate { get; set; }
    }
}
