using System.Linq;
using DiceWorld.Models;

namespace DiceWorld.DTOs
{
    public class BoardGamesDTO
    {
        public IQueryable<BoardGameDTO> BoardGames { get; set; }

        public Meta Meta { get; set; }
    }
}