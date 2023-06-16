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
    public class ProvinceDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProvinceData/ListProvinces
        [HttpGet]
        public IQueryable<Province> ListProvinces()
        {
            return db.Provinces;
        }

        // GET: api/ProvinceData/FindProvince/5
        [ResponseType(typeof(Province))]
        [HttpGet]
        public IHttpActionResult FindProvince(int id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            return Ok(province);
        }

        // POST: api/ProvinceData/UpdateProvince/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateProvince(int id, Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != province.ProvinceID)
            {
                return BadRequest();
            }

            db.Entry(province).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/ProvinceData/AddProvince
        [ResponseType(typeof(Province))]
        [HttpPost]
        public IHttpActionResult AddProvince(Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provinces.Add(province);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = province.ProvinceID }, province);
        }

        // POST: api/ProvinceData/DeleteProvince/5
        [ResponseType(typeof(Province))]
        [HttpPost]
        public IHttpActionResult DeleteProvince(int id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            db.Provinces.Remove(province);
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

        private bool ProvinceExists(int id)
        {
            return db.Provinces.Count(e => e.ProvinceID == id) > 0;
        }
    }
}