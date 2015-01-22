using System.Linq;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class BoardGamesDTO
    {
        public IQueryable<BoardGame> BoardGames { get; set; }

        public Meta Meta { get; set; }
    }
}