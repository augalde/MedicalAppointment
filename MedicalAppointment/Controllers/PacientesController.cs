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
    public class PacientesController : ApiController
    {
        private MedicalAppointmentContext db = new MedicalAppointmentContext();

        // GET: api/Pacientes
        public List<Paciente> GetPacientes()
        {
            List<Paciente> pacientes = db.Pacientes.ToList() as List<Paciente>;
            return pacientes;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> GetPaciente(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.Id)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(paciente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> DeletePaciente(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(paciente);
            await db.SaveChangesAsync();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Pacientes.Count(e => e.Id == id) > 0;
        }
    }
}