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
    public class BoardGameStatsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/BoardGameStats
        public IQueryable<BoardGameStats> GetBoardGameStats()
        {
            return db.BoardGameStats;
        }

        // GET: api/BoardGameStats/5
        [ResponseType(typeof(BoardGameStats))]
        public async Task<IHttpActionResult> GetBoardGameStats(int id)
        {
            BoardGameStats boardGameStats = await db.BoardGameStats.FindAsync(id);
            if (boardGameStats == null)
            {
                return NotFound();
            }

            return Ok(boardGameStats);
        }

        // PUT: api/BoardGameStats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBoardGameStats(int id, BoardGameStats boardGameStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardGameStats.Id)
            {
                return BadRequest();
            }

            db.Entry(boardGameStats).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardGameStatsExists(id))
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

        // POST: api/BoardGameStats
        [ResponseType(typeof(BoardGameStats))]
        public async Task<IHttpActionResult> PostBoardGameStats(BoardGameStats boardGameStats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BoardGameStats.Add(boardGameStats);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoardGameStatsExists(boardGameStats.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = boardGameStats.Id }, boardGameStats);
        }

        // DELETE: api/BoardGameStats/5
        [ResponseType(typeof(BoardGameStats))]
        public async Task<IHttpActionResult> DeleteBoardGameStats(int id)
        {
            BoardGameStats boardGameStats = await db.BoardGameStats.FindAsync(id);
            if (boardGameStats == null)
            {
                return NotFound();
            }

            db.BoardGameStats.Remove(boardGameStats);
            await db.SaveChangesAsync();

            return Ok(boardGameStats);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardGameStatsExists(int id)
        {
            return db.BoardGameStats.Count(e => e.Id == id) > 0;
        }
    }
}