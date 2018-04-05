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
using MedicalAppointment.DAL;

namespace MedicalAppointment.Controllers
{
    public class TipoCitasController : ApiController
    {
        //private MedicalAppointmentContext db = new MedicalAppointmentContext();
        private ITipoCitaRepository tipoCitaRepository;
        public TipoCitasController()
        {
            this.tipoCitaRepository = new TipoCitaRepository(new RepositoryContext());
        }
        // GET: api/TipoCitas
        public List<TipoCita> GetTipoCitas()
        {
            List<TipoCita> tipoCitaList = tipoCitaRepository.GetTipoCitas();
            return tipoCitaList;
        }

        // GET: api/TipoCitas/5
        [ResponseType(typeof(TipoCita))]
        public IHttpActionResult GetTipoCita(int id)
        {
            TipoCita tipoCita = tipoCitaRepository.GetTipoCitaByID(id);
            if (tipoCita == null)
            {
                return NotFound();
            }

            return Ok(tipoCita);
        }

        //// PUT: api/TipoCitas/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutTipoCita(int id, TipoCita tipoCita)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tipoCita.TipoCitaId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tipoCita).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TipoCitaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/TipoCitas
        //[ResponseType(typeof(TipoCita))]
        //public async Task<IHttpActionResult> PostTipoCita(TipoCita tipoCita)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.TipoCitas.Add(tipoCita);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = tipoCita.TipoCitaId }, tipoCita);
        //}

        //// DELETE: api/TipoCitas/5
        //[ResponseType(typeof(TipoCita))]
        //public async Task<IHttpActionResult> DeleteTipoCita(int id)
        //{
        //    TipoCita tipoCita = await db.TipoCitas.FindAsync(id);
        //    if (tipoCita == null)
        //    {
        //        return NotFound();
        //    }

        //    db.TipoCitas.Remove(tipoCita);
        //    await db.SaveChangesAsync();

        //    return Ok(tipoCita);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tipoCitaRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool TipoCitaExists(int id)
        //{
        //    return db.TipoCitas.Count(e => e.TipoCitaId == id) > 0;
        //}
    }
}