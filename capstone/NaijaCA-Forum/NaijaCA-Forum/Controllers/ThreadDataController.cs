using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NaijaCA_Forum.Models;

namespace NaijaCA_Forum.Controllers
{
    public class ThreadDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ThreadData/ListThreads
        [HttpGet]
        public IEnumerable<ThreadDto> ListThreads()
        {

            List<Thread> Threads = db.Threads.ToList();
            List<ThreadDto> ThreadDtos = new List<ThreadDto>();

            Threads.ForEach(
                t=> ThreadDtos.Add(new ThreadDto() { 
                    ThreadID = t.ThreadID,
                    UserName = t.Member.UserName,
                    FavouriteQuote = t.Member.FavouriteQuote,
                    ThreadComment = t.ThreadComment
                }) 
                
                
                );


            return ThreadDtos;
        }

        // GET: api/ThreadData/FindThread/5
        [ResponseType(typeof(Thread))]
        [HttpGet]
        public IHttpActionResult FindThread(int id)
        {
            Thread Thread = db.Threads.Find(id);
            ThreadDto ThreadDto = new ThreadDto()
            {
                ThreadID = Thread.ThreadID,
                UserName = Thread.Member.UserName,
                FavouriteQuote = Thread.Member.FavouriteQuote,
                ThreadComment = Thread.ThreadComment

            };

            if (Thread == null)
            {
                return NotFound();
            }

            return Ok(ThreadDto);
        }

        // PUT: api/ThreadData/UpdateThread/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateThread(int id, Thread thread)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thread.ThreadID)
            {
                return BadRequest();
            }

            db.Entry(thread).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(id))
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

        // POST: api/ThreadData/AddThread
        [ResponseType(typeof(Thread))]
        [HttpPost]
        public IHttpActionResult AddThread(Thread thread)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Threads.Add(thread);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thread.ThreadID }, thread);
        }

        // DELETE: api/ThreadData/DeleteThread/5
        [ResponseType(typeof(Thread))]
        [HttpPost]
        public IHttpActionResult DeleteThread(int id)
        {
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return NotFound();
            }

            db.Threads.Remove(thread);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThreadExists(int id)
        {
            return db.Threads.Count(e => e.ThreadID == id) > 0;
        }
    }
}