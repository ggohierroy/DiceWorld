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
using DiceWorld.Models;

namespace DiceWorld.Controllers
{
    public class BoardGamesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/BoardGames
        public BoardGamesDTO GetBoardGames()
        {
            return new BoardGamesDTO {BoardGames = db.BoardGames};
        }

        // GET: api/BoardGames/5
        [ResponseType(typeof(BoardGame))]
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