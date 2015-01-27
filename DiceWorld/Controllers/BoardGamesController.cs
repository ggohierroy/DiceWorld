using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DiceWorld.DTOs;
using DiceWorld.Models;

namespace DiceWorld.Controllers
{
    [RoutePrefix("api")]
    public class BoardGamesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [Route("boardgames")]
        public BoardGamesDTO GetBoardGames([FromUri] BoardGameSearchParameters parameters)
        {
            var boardGames = db.BoardGames.AsQueryable();

            if (!string.IsNullOrEmpty(parameters.Keyword))
                boardGames = boardGames.Where(b => b.Name.ToLower().Contains(parameters.Keyword.ToLower()));

            if (parameters.PublishedFrom != null)
                boardGames = boardGames.Where(b => b.YearPublished >= parameters.PublishedFrom);

            var page = (int) (parameters.Page ?? 1);
            var itemsPerPage = (int) (parameters.ItemsPerPage ?? 24);

            return new BoardGamesDTO
            {
                BoardGames = boardGames.OrderBy(b => b.BoardGameStats.Rank).Skip((page - 1) * itemsPerPage).Take(itemsPerPage),
                Meta = new Meta { Total = boardGames.Count() }
            };
        }

        [Route("boardgamesForAutocomplete")]
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
        [ResponseType(typeof(BoardGame))]
        [Route("boardgames/{id:int}")]
        public async Task<IHttpActionResult> GetBoardGame(int id)
        {
            BoardGame boardGame = await db.BoardGames.FindAsync(id);
            if (boardGame == null)
            {
                return NotFound();
            }

            return Ok(boardGame);
        }

        // PUT: api/BoardGames/5
        [ResponseType(typeof(void))]
        [Route("boardgames/{id:int}")]
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
        [Route("boardgames")]
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
        [Route("boardgames")]
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

    public class BoardGamesAutocompleteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}