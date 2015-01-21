using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiceWorld.Models;

namespace DiceWorld
{
    public class BoardGamesDTO
    {
        public IQueryable<BoardGame> BoardGames { get; set; }
    }
}