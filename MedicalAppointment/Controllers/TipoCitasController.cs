using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MedicalAppointment.Models;

namespace MedicalAppointment.Controllers
{
    public class TipoCitasController : ApiController
    {
        private MedicalAppointmentContext db = new MedicalAppointmentContext();

        // GET: api/TipoCitas
        public IQueryable<TipoCita> GetTipoCitas()
        {
            return db.TipoCitas;
        }

        // GET: api/TipoCitas/5
        [ResponseType(typeof(TipoCita))]
        public async Task<IHttpActionResult> GetTipoCita(int id)
        {
            TipoCita tipoCita = await db.TipoCitas.FindAsync(id);
            if (tipoCita == null)
            {
                return NotFound();
            }

            return Ok(tipoCita);
        }

        // PUT: api/TipoCitas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoCita(int id, TipoCita tipoCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCita.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCita).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCitaExists(id))
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

        // POST: api/TipoCitas
        [ResponseType(typeof(TipoCita))]
        public async Task<IHttpActionResult> PostTipoCita(TipoCita tipoCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCitas.Add(tipoCita);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoCita.Id }, tipoCita);
        }

        // DELETE: api/TipoCitas/5
        [ResponseType(typeof(TipoCita))]
        public async Task<IHttpActionResult> DeleteTipoCita(int id)
        {
            TipoCita tipoCita = await db.TipoCitas.FindAsync(id);
            if (tipoCita == null)
            {
                return NotFound();
            }

            db.TipoCitas.Remove(tipoCita);
            await db.SaveChangesAsync();

            return Ok(tipoCita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCitaExists(int id)
        {
            return db.TipoCitas.Count(e => e.Id == id) > 0;
        }
    }
}