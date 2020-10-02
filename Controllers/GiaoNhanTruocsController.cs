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
    public class GiaoNhanTruocsController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();

        // GET: api/GiaoNhanTruocs
        public IQueryable<GiaoNhanTruoc> GetGiaoNhanTruocs()
        {
            return db.GiaoNhanTruocs;
        }

        // GET: api/GiaoNhanTruocs/5
        [ResponseType(typeof(GiaoNhanTruoc))]
        public IHttpActionResult GetGiaoNhanTruoc(int id)
        {
            GiaoNhanTruoc giaoNhanTruoc = db.GiaoNhanTruocs.Find(id);
            if (giaoNhanTruoc == null)
            {
                return NotFound();
            }

            return Ok(giaoNhanTruoc);
        }

        // PUT: api/GiaoNhanTruocs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiaoNhanTruoc(int id, GiaoNhanTruoc giaoNhanTruoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giaoNhanTruoc.MaGiaoNhanTruoc)
            {
                return BadRequest();
            }

            db.Entry(giaoNhanTruoc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaoNhanTruocExists(id))
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

        // POST: api/GiaoNhanTruocs
        [ResponseType(typeof(GiaoNhanTruoc))]
        public IHttpActionResult PostGiaoNhanTruoc(GiaoNhanTruoc giaoNhanTruoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GiaoNhanTruocs.Add(giaoNhanTruoc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = giaoNhanTruoc.MaGiaoNhanTruoc }, giaoNhanTruoc);
        }

        // DELETE: api/GiaoNhanTruocs/5
        [ResponseType(typeof(GiaoNhanTruoc))]
        public IHttpActionResult DeleteGiaoNhanTruoc(int id)
        {
            GiaoNhanTruoc giaoNhanTruoc = db.GiaoNhanTruocs.Find(id);
            if (giaoNhanTruoc == null)
            {
                return NotFound();
            }

            db.GiaoNhanTruocs.Remove(giaoNhanTruoc);
            db.SaveChanges();

            return Ok(giaoNhanTruoc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiaoNhanTruocExists(int id)
        {
            return db.GiaoNhanTruocs.Count(e => e.MaGiaoNhanTruoc == id) > 0;
        }
    }
}