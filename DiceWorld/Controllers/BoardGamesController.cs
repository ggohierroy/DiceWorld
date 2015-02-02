using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DiceWorld.Common;
using DiceWorld.DTOs;
using DiceWorld.Models;
using Microsoft.Ajax.Utilities;

namespace DiceWorld.Controllers
{
    [RoutePrefix("api")]
    public class BoardGamesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [Route("Boardgames")]
        public BoardGamesDTO GetBoardGames([FromUri] BoardGameSearchParameters parameters)
        {
            var boardGames = db.BoardGames.AsQueryable();

            var page = 1; 
            var itemsPerPage = 24;
            var sortBy = Sort.Rank;

            if (parameters != null)
            {
                if (!string.IsNullOrEmpty(parameters.Keyword))
                    boardGames = boardGames.Where(b => b.Name.ToLower().Contains(parameters.Keyword.ToLower()));

                if (parameters.PublishedFrom != null)
                    boardGames = boardGames.Where(b => b.YearPublished >= parameters.PublishedFrom);
                if (parameters.PublishedTo != null)
                    boardGames = boardGames.Where(b => b.YearPublished <= parameters.PublishedTo);

                if (parameters.ExactRange)
                {
                    if (parameters.MaxPlayers != null)
                        boardGames = boardGames.Where(b => b.MaxPlayers == parameters.MaxPlayers);
                    if (parameters.MinPlayers != null)
                        boardGames = boardGames.Where(b => b.MinPlayers == parameters.MinPlayers);
                }
                else
                {
                    if (parameters.MaxPlayers != null)
                        boardGames = boardGames.Where(b => b.MaxPlayers >= parameters.MaxPlayers);
                    if (parameters.MinPlayers != null)
                        boardGames = boardGames.Where(b => b.MinPlayers <= parameters.MinPlayers);
                }

                if (parameters.MaxPrice != null)
                    boardGames = boardGames.Where(b => b.Price <= parameters.MaxPrice);
                if (parameters.MinPrice != null)
                    boardGames = boardGames.Where(b => b.Price >= parameters.MinPrice);

                if (parameters.MaxPlayingTime != null)
                    boardGames = boardGames.Where(b => b.PlayingTime <= parameters.MaxPlayingTime);
                if (parameters.MinPlayingTime != null)
                    boardGames = boardGames.Where(b => b.PlayingTime >= parameters.MinPlayingTime);

                if (parameters.MinWeight != null)
                    boardGames = boardGames.Where(b => b.BoardGameStats.AverageWeight >= parameters.MinWeight);
                if (parameters.MaxWeight != null)
                    boardGames = boardGames.Where(b => b.BoardGameStats.AverageWeight <= parameters.MaxWeight);

                if (parameters.MinRating != null)
                    boardGames = boardGames.Where(b => b.BoardGameStats.BayesianRating >= parameters.MinRating);
                if (parameters.MaxRating != null)
                    boardGames = boardGames.Where(b => b.BoardGameStats.BayesianRating <= parameters.MaxRating);

                if (parameters.IncludeTags != null)
                    boardGames = boardGames.Where(b => parameters.IncludeTags.All(i => b.Tags.Select(c => c.TagDefinitionId).Contains(i)));

                if (parameters.Page.HasValue)
                    page = (int) parameters.Page.Value;

                if (parameters.ItemsPerPage.HasValue)
                    itemsPerPage = (int)parameters.ItemsPerPage.Value;

                if (parameters.SortBy.HasValue)
                    sortBy = parameters.SortBy.Value;
            }

            var total = boardGames.Count();

            boardGames = boardGames.Include(b => b.Tags);

            switch(sortBy)
            {
                case Sort.Rank:
                    boardGames = boardGames.OrderBy(b => b.BoardGameStats.Rank);
                    break;
                case Sort.Hotness:
                    boardGames = boardGames.OrderByDescending(b => b.BoardGameStats.Hotness);
                    break;
                default:
                    boardGames = boardGames.OrderBy(b => b.BoardGameStats.Rank);
                    break;
            }
                
            boardGames = boardGames.Skip((page - 1)*itemsPerPage)
                .Take(itemsPerPage);

            return new BoardGamesDTO
            {
                BoardGames = boardGames.Select(b => new BoardGameDTO
                {
                    BGGId = b.BGGId,
                    BoardGameStat = b.Id, // One-to-one relationship = same id
                    Description = b.Description,
                    Id = b.Id,
                    ImageId = b.ImageId,
                    MaxPlayers = b.MaxPlayers,
                    MinAge = b.MinAge,
                    MinPlayers = b.MinPlayers,
                    Name = b.Name,
                    PlayingTime = b.PlayingTime,
                    Price = b.Price,
                    TagDefinitions = b.Tags.Select(t => t.TagDefinitionId).ToList(),
                    YearPublished = b.YearPublished
                }),
                Meta = new Meta { Total = total }
            };
        }

        [Route("BoardGamesForAutocomplete")]
        public IQueryable<BoardGamesAutocompleteDTO> GetBoardGamesForAutoComplete(string keyword)
        {
            return db.BoardGames
                .Where(b => b.Name.Contains(keyword))
                .OrderBy(b => b.BoardGameStats.Rank)
                .Skip(0).Take(5)
                .Select(b => new BoardGamesAutocompleteDTO
                {
                    Id = b.Id, 
                    Name = b.Name
                });
        }

        // GET: api/BoardGames/5
        [ResponseType(typeof(BoardGameContainerDTO))]
        [Route("BoardGames/{id:int}")]
        public async Task<IHttpActionResult> GetBoardGame(int id)
        {
            var boardGame = await db.BoardGames
                .Include(b => b.Tags.Select(t => t.TagDefinition))
                .Include(b => b.BoardGameStats)
                .SingleOrDefaultAsync(b => b.Id == id);
            
            if (boardGame == null)
            {
                return NotFound();
            }

            return Ok(new BoardGameContainerDTO
            {
                BoardGame = new BoardGameDTO
                {
                    BGGId = boardGame.BGGId,
                    BoardGameStat = boardGame.Id, // One-to-one relationship = same id
                    Description = boardGame.Description,
                    Id = boardGame.Id,
                    ImageId = boardGame.ImageId,
                    MaxPlayers = boardGame.MaxPlayers,
                    MinAge = boardGame.MinAge,
                    MinPlayers = boardGame.MinPlayers,
                    Name = boardGame.Name,
                    PlayingTime = boardGame.PlayingTime,
                    Price = boardGame.Price,
                    TagDefinitions = boardGame.Tags.Select(t => t.TagDefinitionId).ToList(),
                    YearPublished = boardGame.YearPublished
                },
                //TagDefinitions = boardGame.Tags.Select(t => t.TagDefinition).ToList(),
                BoardGameStat = new List<BoardGameStats> { boardGame.BoardGameStats }
            });
        }

        // PUT: api/BoardGames/5
        [ResponseType(typeof(void))]
        [Route("BoardGames/{id:int}")]
        public async Task<IHttpActionResult> PutBoardGame(int id, BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardGame.Id)
            {
                return BadRequest();
            }

            db.Entry(boardGame).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BoardGames
        [ResponseType(typeof(BoardGame))]
        [Route("BoardGames")]
        public async Task<IHttpActionResult> PostBoardGame(BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BoardGames.Add(boardGame);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = boardGame.Id }, boardGame);
        }

        // DELETE: api/BoardGames/5
        [ResponseType(typeof(BoardGame))]
        [Route("BoardGames")]
        public async Task<IHttpActionResult> DeleteBoardGame(int id)
        {
            BoardGame boardGame = await db.BoardGames.FindAsync(id);
            if (boardGame == null)
            {
                return NotFound();
            }

            db.BoardGames.Remove(boardGame);
            await db.SaveChangesAsync();

            return Ok(boardGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardGameExists(int id)
        {
            return db.BoardGames.Count(e => e.Id == id) > 0;
        }
    }
}