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
    public class TagDefinitionsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/TagDefinitions
        public IQueryable<TagDefinition> GetTagDefinitions()
        {
            return db.TagDefinitions;
        }

        // GET: api/TagDefinitions/5
        [ResponseType(typeof(TagDefinition))]
        public async Task<IHttpActionResult> GetTagDefinition(int id)
        {
            TagDefinition tagDefinition = await db.TagDefinitions.FindAsync(id);
            if (tagDefinition == null)
            {
                return NotFound();
            }

            return Ok(tagDefinition);
        }

        [Route("tagDefinitionsForAutocomplete")]
        public IQueryable<TagDefinitionsAutocompleteDTO> GetTagDefinitionsForAutoComplete(string keyword)
        {
            return db.TagDefinitions
                .Where(b => b.Name.Contains(keyword))
                .OrderByDescending(b => b.Occurences)
                .Skip(0).Take(5)
                .Select(b => new TagDefinitionsAutocompleteDTO
                {
                    Id = b.Id,
                    Name = b.Name
                });
        }

        // PUT: api/TagDefinitions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTagDefinition(int id, TagDefinition tagDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tagDefinition.Id)
            {
                return BadRequest();
            }

            db.Entry(tagDefinition).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagDefinitionExists(id))
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

        // POST: api/TagDefinitions
        [ResponseType(typeof(TagDefinition))]
        public async Task<IHttpActionResult> PostTagDefinition(TagDefinition tagDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TagDefinitions.Add(tagDefinition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tagDefinition.Id }, tagDefinition);
        }

        // DELETE: api/TagDefinitions/5
        [ResponseType(typeof(TagDefinition))]
        public async Task<IHttpActionResult> DeleteTagDefinition(int id)
        {
            TagDefinition tagDefinition = await db.TagDefinitions.FindAsync(id);
            if (tagDefinition == null)
            {
                return NotFound();
            }

            db.TagDefinitions.Remove(tagDefinition);
            await db.SaveChangesAsync();

            return Ok(tagDefinition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagDefinitionExists(int id)
        {
            return db.TagDefinitions.Count(e => e.Id == id) > 0;
        }
    }
}