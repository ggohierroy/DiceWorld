using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DiceWorld.Models
{
    public class TagDefinition
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public int BGGId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Occurences { get; set; }

        public int TagTypeId { get; set; }

        public bool IsImportant { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime? DeletedDate { get; set; }
    }
}
