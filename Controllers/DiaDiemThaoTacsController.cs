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
    public class DiaDiemThaoTacsController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();

        // GET: api/DiaDiemThaoTacs
        public IQueryable<DiaDiemThaoTac> GetDiaDiemThaoTacs()
        {
            return db.DiaDiemThaoTacs;
        }

        // GET: api/DiaDiemThaoTacs/5
        [ResponseType(typeof(DiaDiemThaoTac))]
        public IHttpActionResult GetDiaDiemThaoTac(string id)
        {
            DiaDiemThaoTac diaDiemThaoTac = db.DiaDiemThaoTacs.Find(id);
            if (diaDiemThaoTac == null)
            {
                return NotFound();
            }

            return Ok(diaDiemThaoTac);
        }

        // PUT: api/DiaDiemThaoTacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiaDiemThaoTac(string id, DiaDiemThaoTac diaDiemThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diaDiemThaoTac.MaDiaDiemThaoTac)
            {
                return BadRequest();
            }

            db.Entry(diaDiemThaoTac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaDiemThaoTacExists(id))
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

        // POST: api/DiaDiemThaoTacs
        [ResponseType(typeof(DiaDiemThaoTac))]
        public IHttpActionResult PostDiaDiemThaoTac(DiaDiemThaoTac diaDiemThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DiaDiemThaoTacs.Add(diaDiemThaoTac);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiaDiemThaoTacExists(diaDiemThaoTac.MaDiaDiemThaoTac))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = diaDiemThaoTac.MaDiaDiemThaoTac }, diaDiemThaoTac);
        }

        // DELETE: api/DiaDiemThaoTacs/5
        [ResponseType(typeof(DiaDiemThaoTac))]
        public IHttpActionResult DeleteDiaDiemThaoTac(string id)
        {
            DiaDiemThaoTac diaDiemThaoTac = db.DiaDiemThaoTacs.Find(id);
            if (diaDiemThaoTac == null)
            {
                return NotFound();
            }

            db.DiaDiemThaoTacs.Remove(diaDiemThaoTac);
            db.SaveChanges();

            return Ok(diaDiemThaoTac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiaDiemThaoTacExists(string id)
        {
            return db.DiaDiemThaoTacs.Count(e => e.MaDiaDiemThaoTac == id) > 0;
        }
    }
}