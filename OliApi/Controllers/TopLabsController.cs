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
using OliApi;
using EntityState = System.Data.Entity.EntityState;

namespace OliApi.Controllers
{
    public class TopLabsController : ApiController
    {
        private OliModel db = new OliModel();

        // GET: api/TopLabs
        public IQueryable<TopLab> GetTopLab()
        {
            var ts = db.TopLab.OrderByDescending(t => t.Datum).Take(10);
            return ts;
        }

        // GET: api/TopLabs/5
        [ResponseType(typeof(TopLab))]
        public async Task<IHttpActionResult> GetTopLab(Guid id)
        {
            TopLab topLab = await db.TopLab.FindAsync(id);
            if (topLab == null)
            {
                return NotFound();
            }

            return Ok(topLab);
        }

        // PUT: api/TopLabs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopLab(Guid id, TopLab topLab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topLab.TopLabGuid)
            {
                return BadRequest();
            }

            db.Entry(topLab).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopLabExists(id))
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

        // POST: api/TopLabs
        [ResponseType(typeof(TopLab))]
        public async Task<IHttpActionResult> PostTopLab(TopLab topLab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TopLab.Add(topLab);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopLabExists(topLab.TopLabGuid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = topLab.TopLabGuid }, topLab);
        }

        // DELETE: api/TopLabs/5
        [ResponseType(typeof(TopLab))]
        //public async Task<IHttpActionResult> DeleteTopLab(Guid id)
        //{
        //    TopLab topLab = await db.TopLab.FindAsync(id);
        //    if (topLab == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TopLab.Remove(topLab);
        //    await db.SaveChangesAsync();

        //    return Ok(topLab);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopLabExists(Guid id)
        {
            return db.TopLab.Count(e => e.TopLabGuid == id) > 0;
        }
    }
}