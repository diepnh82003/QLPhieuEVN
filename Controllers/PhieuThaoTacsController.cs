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
    public class PhieuThaoTacsController : ApiController
    {
        private QLPhieuDienLucEntities db = new QLPhieuDienLucEntities();
        [Route("PhieuThaoTacs")]
        public List<MaTenTT_PhieuTT> GetPhieuThaoTac3()
        {
            List<MaTenTT_PhieuTT> dsphieuttout = new List<MaTenTT_PhieuTT>();
            List<PhieuThaoTac> dsphieutt = db.PhieuThaoTacs.ToList();
            if (dsphieutt == null)
            {
                return null;
            }


            foreach (PhieuThaoTac phieuThaoTac in dsphieutt)
            {
                MaTenTT_PhieuTT result = new MaTenTT_PhieuTT();
                result.MaPhieuThaoTac = phieuThaoTac.MaPhieuThaoTac;
                result.TenPhieuThaoTac = phieuThaoTac.TenPhieuThaoTac;
                result.TrangThai = phieuThaoTac.TrangThai;
                dsphieuttout.Add(result);
            }
            return dsphieuttout;
        }
        // GET: api/PhieuThaoTacs
        public IQueryable<PhieuThaoTac> GetPhieuThaoTacs()
        {
            return db.PhieuThaoTacs;
        }

        // GET: api/PhieuThaoTacs/5
        [ResponseType(typeof(PhieuThaoTac))]
        public IHttpActionResult GetPhieuThaoTac(string id)
        {
            PhieuThaoTac phieuThaoTac = db.PhieuThaoTacs.Find(id);
            if (phieuThaoTac == null)
            {
                return NotFound();
            }

            return Ok(phieuThaoTac);
        }

        // PUT: api/PhieuThaoTacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuThaoTac(string id, PhieuThaoTac phieuThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuThaoTac.MaPhieuThaoTac)
            {
                return BadRequest();
            }

            db.Entry(phieuThaoTac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuThaoTacExists(id))
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

        // POST: api/PhieuThaoTacs
        [ResponseType(typeof(PhieuThaoTac))]
        public IHttpActionResult PostPhieuThaoTac(PhieuThaoTac phieuThaoTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuThaoTacs.Add(phieuThaoTac);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PhieuThaoTacExists(phieuThaoTac.MaPhieuThaoTac))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = phieuThaoTac.MaPhieuThaoTac }, phieuThaoTac);
        }

        // DELETE: api/PhieuThaoTacs/5
        [ResponseType(typeof(PhieuThaoTac))]
        public IHttpActionResult DeletePhieuThaoTac(string id)
        {
            PhieuThaoTac phieuThaoTac = db.PhieuThaoTacs.Find(id);
            if (phieuThaoTac == null)
            {
                return NotFound();
            }

            db.PhieuThaoTacs.Remove(phieuThaoTac);
            db.SaveChanges();

            return Ok(phieuThaoTac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuThaoTacExists(string id)
        {
            return db.PhieuThaoTacs.Count(e => e.MaPhieuThaoTac == id) > 0;
        }
    }
}