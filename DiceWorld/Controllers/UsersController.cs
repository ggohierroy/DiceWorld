using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DiceWorld.DTOs;
using DiceWorld.Models;
using Microsoft.AspNet.Identity;

namespace DiceWorld.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [ResponseType(typeof (userDTO))]
        [Route("users/{id:int}")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var userId = User.Identity.GetUserId<int>();

            var cart = await db.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            return Ok(new userDTO
            {
                Cart = cart == null ? null : (int?) cart.Id,
                Id = userId,
                Orders = null
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
