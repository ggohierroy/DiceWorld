using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class BoardGameContainerDTO
    {
        public BoardGameDTO BoardGame { get; set; }

        //public List<TagDefinition> TagDefinitions { get; set; }

        public List<BoardGameStats> BoardGameStat { get; set; }
    }
}