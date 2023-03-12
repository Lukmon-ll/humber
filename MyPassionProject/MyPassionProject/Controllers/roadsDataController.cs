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
using MyPassionProject.Models;

namespace MyPassionProject.Controllers
{
    public class roadsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/roadsData/Listroads
        [HttpGet]
        public IEnumerable<roadDto> Listroads()
        {
            List<road> roads = db.roads.ToList();
            List<roadDto> roadDtos = new List<roadDto>();

            roads.ForEach(r => roadDtos.Add(new roadDto()
            {
                roadId = r.roadId,
                posterFirstName = r.posterFirstName,
                posterLastName = r.posterLastName,
                streetName = r.streetName,
                roadLength = r.roadLength,
                roadImage = r.roadImage,
                roadStatus = r.roadStatus,
                localGovnName = r.localGovn.localGovnName

            }));

            return roadDtos;
        }

        // GET: api/roadsData/Findroad/5
        [ResponseType(typeof(road))]
        [HttpGet]
        public IHttpActionResult Findroad(int id)
        {
            road road = db.roads.Find(id);
            roadDto roadDto = new roadDto()
            {
                posterFirstName = road.posterFirstName,
                posterLastName = road.posterLastName,
                streetName = road.streetName,
                roadLength = road.roadLength,
                roadImage = road.roadImage,
                roadId = road.roadId,
                roadStatus = road.roadStatus,
                localGovnName = road.localGovn.localGovnName
            };

            if (road == null)
            {
                return NotFound();
            }

            return Ok(roadDto);
        }

        // POST: api/roadsData/Updateroad/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Updateroad(int id, road road)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != road.roadId)
            {
                return BadRequest();
            }

            db.Entry(road).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roadExists(id))
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

        // POST: api/roadsData/Addroad
        [ResponseType(typeof(road))]
        [HttpPost]
        public IHttpActionResult Addroad(road road)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.roads.Add(road);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = road.roadId }, road);
        }

        // POST: api/roadsData/Deleteroad/5
        [ResponseType(typeof(road))]
        [HttpPost]
        public IHttpActionResult Deleteroad(int id)
        {
            road road = db.roads.Find(id);
            if (road == null)
            {
                return NotFound();
            }

            db.roads.Remove(road);
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

        private bool roadExists(int id)
        {
            return db.roads.Count(e => e.roadId == id) > 0;
        }
    }
}