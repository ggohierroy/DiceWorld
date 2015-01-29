using System.Linq;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class TagDefinitionsDTO
    {
        public IQueryable<TagDefinition> TagDefinitions { get; set; }

        public Meta Meta { get; set; }
    }
}