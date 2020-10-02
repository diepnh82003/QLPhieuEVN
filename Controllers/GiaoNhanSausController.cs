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
using QLPhieuEVN.Models;

namespace QLPhieuEVN.Controllers
{
    public class GiaoNhanSausController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();

        // GET: api/GiaoNhanSaus
        public IQueryable<GiaoNhanSau> GetGiaoNhanSaus()
        {
            return db.GiaoNhanSaus;
        }

        // GET: api/GiaoNhanSaus/5
        [ResponseType(typeof(GiaoNhanSau))]
        public IHttpActionResult GetGiaoNhanSau(int id)
        {
            GiaoNhanSau giaoNhanSau = db.GiaoNhanSaus.Find(id);
            if (giaoNhanSau == null)
            {
                return NotFound();
            }

            return Ok(giaoNhanSau);
        }

        // PUT: api/GiaoNhanSaus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiaoNhanSau(int id, GiaoNhanSau giaoNhanSau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaoNhanSau.MaGiaoNhanSau)
            {
                return BadRequest();
            }

            db.Entry(giaoNhanSau).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaoNhanSauExists(id))
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

        // POST: api/GiaoNhanSaus
        [ResponseType(typeof(GiaoNhanSau))]
        public IHttpActionResult PostGiaoNhanSau(GiaoNhanSau giaoNhanSau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GiaoNhanSaus.Add(giaoNhanSau);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = giaoNhanSau.MaGiaoNhanSau }, giaoNhanSau);
        }

        // DELETE: api/GiaoNhanSaus/5
        [ResponseType(typeof(GiaoNhanSau))]
        public IHttpActionResult DeleteGiaoNhanSau(int id)
        {
            GiaoNhanSau giaoNhanSau = db.GiaoNhanSaus.Find(id);
            if (giaoNhanSau == null)
            {
                return NotFound();
            }

            db.GiaoNhanSaus.Remove(giaoNhanSau);
            db.SaveChanges();

            return Ok(giaoNhanSau);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiaoNhanSauExists(int id)
        {
            return db.GiaoNhanSaus.Count(e => e.MaGiaoNhanSau == id) > 0;
        }
    }
}