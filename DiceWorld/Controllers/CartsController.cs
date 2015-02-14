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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DiceWorld.Controllers
{
    [RoutePrefix("api")]
    public class CartsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Carts/5
        [Route("carts/{id:int}")]
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> GetCart(int id)
        {
            var userId = User.Identity.GetUserId<int>();

            var cart = await db.Carts
                .Include(c => c.CartItems.Select(ci => ci.BoardGame.Tags))
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(new CartContainerDTO 
            { 
                Cart = new CartDTO
                {
                    Id = cart.Id,
                    User = cart.UserId,
                    CartItems = cart.CartItems.Select(ci => ci.Id).ToList()
                },
                CartItems = cart.CartItems.Select(c => new CartItemDTO
                {
                    BoardGame = c.BoardGameId,
                    Cart = c.CartId,
                    Id = c.Id,
                    Quantity = c.Quantity
                }).ToList(),
                BoardGames = cart.CartItems.Select(c => new BoardGameDTO
                {
                    BGGId = c.BoardGame.BGGId,
                    BoardGameStat = c.BoardGame.Id, // One-to-one relationship = same id
                    Description = c.BoardGame.Description,
                    Id = c.BoardGame.Id,
                    ImageId = c.BoardGame.ImageId,
                    MaxPlayers = c.BoardGame.MaxPlayers,
                    MinAge = c.BoardGame.MinAge,
                    MinPlayers = c.BoardGame.MinPlayers,
                    Name = c.BoardGame.Name,
                    PlayingTime = c.BoardGame.PlayingTime,
                    Price = c.BoardGame.Price,
                    TagDefinitions = c.BoardGame.Tags.Select(t => t.TagDefinitionId).ToList(),
                    YearPublished = c.BoardGame.YearPublished
                }).ToList()
            });
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> DeleteCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            await db.SaveChangesAsync();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}