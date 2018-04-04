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
    public class PacientesController : ApiController
    {
        //private MedicalAppointmentContext db = new MedicalAppointmentContext();

        private IPacienteRepository pacienteRepository;

        public PacientesController()
        {
            this.pacienteRepository = new PacienteRepository(new RepositoryContext());
        }
        // GET: api/Pacientes
        public List<Paciente> GetPacientes()
        {
           //List<Paciente> pacientes = db.Pacientes.ToList() as List<Paciente>;
            List<Paciente> pacientes = pacienteRepository.GetPacientes();
            return pacientes;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(int id)
        {
            /*Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }*/

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Paciente paciente =  pacienteRepository.GetPacienteByID(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            //db.Entry(paciente).State = EntityState.Modified;
            pacienteRepository.UpdatePaciente(paciente);            

            try
            {
                pacienteRepository.Save();
                return Ok();
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(paciente.PacienteId))
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
        [HttpPost]
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Pacientes.Add(paciente);
            //await db.SaveChangesAsync();
            pacienteRepository.InsertPaciente(paciente);
            pacienteRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = paciente.PacienteId }, paciente);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(int id)
        {
            //Paciente paciente = await db.Pacientes.FindAsync(id);
            //if (paciente == null)
            //{
            //    return NotFound();
            //}

            //db.Pacientes.Remove(paciente);
            //await db.SaveChangesAsync();

            Paciente paciente = pacienteRepository.GetPacienteByID(id);
            if (paciente == null)
            {
                return NotFound();
            }
            pacienteRepository.DeletePaciente(id);
            pacienteRepository.Save();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                pacienteRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            //return db.Pacientes.Count(e => e.Id == id) > 0;
            Paciente paciente = pacienteRepository.GetPacienteByID(id);
            if (paciente == null)
            {
                return false;
            }
            return true;
        }
    }
}