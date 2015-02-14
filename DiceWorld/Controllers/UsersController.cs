using System.Data.Entity;
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

        [ResponseType(typeof (UserDTO))]
        [Route("users/{id:int}")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var userId = User.Identity.GetUserId<int>();

            var cart = await db.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            return Ok(new UserContainerDTO
            { 
                User = new UserDTO
                {
                    Cart = cart == null ? null : (int?) cart.Id,
                    Name = User.Identity.Name,
                    Id = userId,
                    Orders = null
                }
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
