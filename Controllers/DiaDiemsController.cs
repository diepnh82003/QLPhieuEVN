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
    public class DiaDiemsController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();

        // GET: api/DiaDiems
        public IQueryable<DiaDiem> GetDiaDiems()
        {
            return db.DiaDiems;
        }

        // GET: api/DiaDiems/5
        [ResponseType(typeof(DiaDiem))]
        public IHttpActionResult GetDiaDiem(string id)
        {
            DiaDiem diaDiem = db.DiaDiems.Find(id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return Ok(diaDiem);
        }

        // PUT: api/DiaDiems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiaDiem(string id, DiaDiem diaDiem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diaDiem.MaDiaDiem)
            {
                return BadRequest();
            }

            db.Entry(diaDiem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaDiemExists(id))
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

        // POST: api/DiaDiems
        [ResponseType(typeof(DiaDiem))]
        public IHttpActionResult PostDiaDiem(DiaDiem diaDiem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DiaDiems.Add(diaDiem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiaDiemExists(diaDiem.MaDiaDiem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = diaDiem.MaDiaDiem }, diaDiem);
        }

        // DELETE: api/DiaDiems/5
        [ResponseType(typeof(DiaDiem))]
        public IHttpActionResult DeleteDiaDiem(string id)
        {
            DiaDiem diaDiem = db.DiaDiems.Find(id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            db.DiaDiems.Remove(diaDiem);
            db.SaveChanges();

            return Ok(diaDiem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiaDiemExists(string id)
        {
            return db.DiaDiems.Count(e => e.MaDiaDiem == id) > 0;
        }
    }
}