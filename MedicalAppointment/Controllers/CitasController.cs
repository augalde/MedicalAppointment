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
    public class CitasController : ApiController
    {
        //private MedicalAppointmentContext db = new MedicalAppointmentContext();
        private ICitaRepository citaRepository;

        public CitasController(ICitaRepository citaRepository)
        {
            //this.citaRepository = new CitaRepository(new RepositoryContext());
            this.citaRepository = citaRepository;
        }
        public CitasController()
        {
            this.citaRepository = new CitaRepository(new RepositoryContext());
            
        }
        // GET: api/Citas
        public List<Cita> GetCitas()
        {
            List<Cita> citas = citaRepository.GetCitas();
            return citas;
        }

        // GET: api/Citas/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCita(int id)
        {
            Cita cita = citaRepository.GetCitaByID(id);//await db.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }

        // PUT: api/Citas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCita(int id, Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cita.Id)
            {
                return BadRequest();
            }

            //db.Entry(cita).State = EntityState.Modified;
            citaRepository.UpdateCita(cita);
            try
            {
                //await db.SaveChangesAsync();
                citaRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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

        // POST: api/Citas
        [ResponseType(typeof(Cita))]
        public IHttpActionResult PostCita(Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Citas.Add(cita);
            //await db.SaveChangesAsync();

            //cita.PacienteId.Id
                
            citaRepository.InsertCita(cita);
            citaRepository.Save();

            return CreatedAtRoute("DefaultApi", new { id = cita.Id }, cita);
        }

        // DELETE: api/Citas/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult DeleteCita(int id)
        {
            Cita cita = citaRepository.GetCitaByID(id);//await db.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            //db.Citas.Remove(cita);
            //await db.SaveChangesAsync();
            citaRepository.DeleteCita(id);
            citaRepository.Save();
            return Ok(cita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                citaRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitaExists(int id)
        {
            Cita cita = citaRepository.GetCitaByID(id);
            if (cita == null)
            {
                return false;
            }
            return true;
        }
    }
}