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
    public class TrinhTuThaoTacsController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();

        // GET: api/TrinhTuThaoTacs
        public IQueryable<TrinhTuThaoTac> GetTrinhTuThaoTacs()
        {
            return db.TrinhTuThaoTacs;
        }

        // GET: api/TrinhTuThaoTacs/5
        [ResponseType(typeof(TrinhTuThaoTac))]
        public IHttpActionResult GetTrinhTuThaoTac(int id)
        {
            TrinhTuThaoTac trinhTuThaoTac = db.TrinhTuThaoTacs.Find(id);
            if (trinhTuThaoTac == null)
            {
                return NotFound();
            }

            return Ok(trinhTuThaoTac);
        }

        // PUT: api/TrinhTuThaoTacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrinhTuThaoTac(int id, TrinhTuThaoTac trinhTuThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trinhTuThaoTac.MaTrinhTuThaoTac)
            {
                return BadRequest();
            }

            db.Entry(trinhTuThaoTac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrinhTuThaoTacExists(id))
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

        // POST: api/TrinhTuThaoTacs
        [ResponseType(typeof(TrinhTuThaoTac))]
        public IHttpActionResult PostTrinhTuThaoTac(TrinhTuThaoTac trinhTuThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrinhTuThaoTacs.Add(trinhTuThaoTac);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trinhTuThaoTac.MaTrinhTuThaoTac }, trinhTuThaoTac);
        }

        // DELETE: api/TrinhTuThaoTacs/5
        [ResponseType(typeof(TrinhTuThaoTac))]
        public IHttpActionResult DeleteTrinhTuThaoTac(int id)
        {
            TrinhTuThaoTac trinhTuThaoTac = db.TrinhTuThaoTacs.Find(id);
            if (trinhTuThaoTac == null)
            {
                return NotFound();
            }

            db.TrinhTuThaoTacs.Remove(trinhTuThaoTac);
            db.SaveChanges();

            return Ok(trinhTuThaoTac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrinhTuThaoTacExists(int id)
        {
            return db.TrinhTuThaoTacs.Count(e => e.MaTrinhTuThaoTac == id) > 0;
        }
    }
}