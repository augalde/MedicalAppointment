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
using MedicalAppointment.Filters;

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
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCita( Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //validations for dates
            if (isIn24hr(cita.Fecha))
            {
                return BadRequest("La fecha de la cita no puede estar dentro de las proximas 24 horas.");
            }

            //TODO, citas are atteched, I need to detach the context before update 
            //if (IsAnyCitaSameDate(cita))
            //{
            //    return BadRequest("Ya posee una cita para ese dia, por favor seleccione otra fecha");
            //}

            //db.Entry(cita).State = EntityState.Modified;
            citaRepository.UpdateCita(cita);
            try
            {
                //await db.SaveChangesAsync();
                citaRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(cita.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cita);
        }

        //Move the code to the BL and perform validations
        //Server Side valitation
        private bool isIn24hr(DateTime citaTime)
        {
            if(citaTime < DateTime.Now.AddHours(24))
            {
                return true;
            }
            return false;
        }
        private bool IsAnyCitaSameDate(Cita cita)
        {
            
            List<Cita> readCitas = citaRepository.GetCitas().Where(x => x.PacienteId == cita.PacienteId && x.Fecha.Date == cita.Fecha.Date && x.Id != cita.Id).ToList();
            if (readCitas == null || readCitas.Count() <=0 )
            {
                return false;
            }
            return true;
        }

        // POST: api/Citas
        [ValidatingCita]
        [ResponseType(typeof(Cita))]
        public IHttpActionResult PostCita(Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //validations for dates
            if (isIn24hr(cita.Fecha))
            {
                return BadRequest("La fecha de la cita no puede estar dentro de las proximas 24 horas." );
            }

            if(IsAnyCitaSameDate(cita))
            {
                return BadRequest("Ya posee una cita para ese dia, por favor seleccione otra fecha");
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