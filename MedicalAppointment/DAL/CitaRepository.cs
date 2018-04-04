using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalAppointment.Models;
using System.Data.Entity;

namespace MedicalAppointment.DAL
{
    public class CitaRepository : ICitaRepository, IDisposable
    {
        private RepositoryContext _context;
        private bool disposed = false;

        public CitaRepository(RepositoryContext context)
        {
            this._context = context;
        }
        public void DeleteCita(int? citaId)
        {
            Cita cita = _context.Cita.Find(citaId);
            _context.Cita.Remove(cita);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            // Prevent the GC from calling Object.Finalize on an 
            // object that does not require it
            GC.SuppressFinalize(this);
        }

        public List<Cita> GetCitas()
        {
            return _context.Cita.ToList();
        }

        public Cita GetCitaByID(int? citaId)
        {
            return _context.Cita.Find(citaId);
        }

        public void InsertCita(Cita cita)
        {
            _context.Cita.Add(cita);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateCita(Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;
        }
    }
}