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
using Microsoft.Ajax.Utilities;
using NaijaCA_Forum.Models;
using Member = NaijaCA_Forum.Models.Member;

namespace NaijaCA_Forum.Controllers
{
    public class MemberDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MemberData/ListMembers
        [HttpGet]
        public IEnumerable<MemberDto> ListMembers()
        {

            List<Member> Members = db.Members.ToList();
            List<MemberDto> MemberDtos = new List<MemberDto>();

            Members.ForEach(
                m => MemberDtos.Add(new MemberDto() { 
                MemberID = m.MemberID,
                UserName = m.UserName,
                FirstName = m.FirstName,
                LastName = m.LastName,
                LandedDate = m.LandedDate,
                FavouriteQuote = m.FavouriteQuote,
                Comment = m.Comment,
                ProvinceName = m.Province.ProvinceName,
                CityName = m.City.CityName,
                ProfilePic = m.ProfilePic

                })
                );

            


            return MemberDtos;
        }

        // GET: api/MemberData/FindMember/5
        [ResponseType(typeof(Member))]
        [HttpGet]
        public IHttpActionResult FindMember(int id)
        {
            Member Member = db.Members.Find(id);
            MemberDto MemberDto = new MemberDto()
            {
                MemberID = Member.MemberID,
                UserName = Member.UserName,
                FirstName = Member.FirstName,
                LastName = Member.LastName,
                LandedDate = Member.LandedDate,
                FavouriteQuote = Member.FavouriteQuote,
                Comment = Member.Comment,
                ProvinceName = Member.Province.ProvinceName,
                CityName = Member.City.CityName,
                ProvinceID = Member.ProvinceID,
                CityID = Member.CityID,
                ProfilePic = Member.ProfilePic
            };

            if (Member == null)
            {
                return NotFound();
            }

            return Ok(MemberDto);
        }

        // POST: api/MemberData/UpdateMember/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateMember(int id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.MemberID)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/MemberData/AddMember
        [ResponseType(typeof(Member))]
        [HttpPost]
        public IHttpActionResult AddMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = member.MemberID }, member);
        }

        // POST: api/MemberData/5
        [ResponseType(typeof(Member))]
        [HttpPost]
        public IHttpActionResult DeleteMember(int id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
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

        private bool MemberExists(int id)
        {
            return db.Members.Count(e => e.MemberID == id) > 0;
        }
    }
}