using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Effort;

namespace OliApi.Controllers
{
    public class PostItsController : ApiController
    {
        private readonly OliModel db = new OliModel();

        // GET: api/PostIts
        //public async Task<IList> GetPostIt()
        //{
        //    var connection = DbConnectionFactory.CreateTransient();

        //    var context = new OliModel(connection);
        //    var postit = new PostIt();
        //    postit.Titel = "My title";
        //    postit.PostItGuid = new Guid("e8c4809c-851b-4819-a727-0b987b4fb45f");
        //    context.PostIt.Add(postit);

        //    var x = await context.PostIt.ToListAsync();
        //    return Ok(x);
        //    //var ps = db.PostIt.OrderByDescending(p => p.Datum).Take(10);
        //    //return ps;
        //}

        // GET: api/PostIts/5
        [ResponseType(typeof (PostIt))]
        public async Task<IHttpActionResult> GetPostIt(Guid id)
        {
            var connection = DbConnectionFactory.CreateTransient();

            var context = new OliModel(connection);
            var postit = new PostIt();
            postit.Titel = "My title";
            postit.PostItGuid = new Guid("e8c4809c-851b-4819-a727-0b987b4fb45f");
            context.PostIt.Add(postit);

            var x = await context.PostIt.FindAsync(id);
            return Ok(x);
            //PostIt postIt = await db.PostIt.FindAsync(id);
            //if (postIt == null)
            //{
            //    return NotFound();
            //}

            //return Ok(postIt);
        }

        // PUT: api/PostIts/5
        [ResponseType(typeof (void))]
        public async Task<IHttpActionResult> PutPostIt(Guid id, PostIt postIt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postIt.PostItGuid)
            {
                return BadRequest();
            }

            db.Entry(postIt).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PostIts
        [ResponseType(typeof (PostIt))]
        public async Task<IHttpActionResult> PostPostIt(PostIt postIt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostIt.Add(postIt);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostItExists(postIt.PostItGuid))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = postIt.PostItGuid}, postIt);
        }

        // DELETE: api/PostIts/5
        [ResponseType(typeof (PostIt))]
        public async Task<IHttpActionResult> DeletePostIt(Guid id)
        {
            var postIt = await db.PostIt.FindAsync(id);
            if (postIt == null)
            {
                return NotFound();
            }

            db.PostIt.Remove(postIt);
            await db.SaveChangesAsync();

            return Ok(postIt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostItExists(Guid id)
        {
            return db.PostIt.Count(e => e.PostItGuid == id) > 0;
        }
    }
}