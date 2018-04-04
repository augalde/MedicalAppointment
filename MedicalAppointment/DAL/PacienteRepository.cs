using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MedicalAppointment.Models;
using System.Data.Entity;

namespace MedicalAppointment.DAL
{
    public class PacienteRepository : IPacienteRepository, IDisposable
    {
        private RepositoryContext _context;

        public PacienteRepository(RepositoryContext context)
        {
            this._context = context;
        }
        public void DeletePaciente(int? pacienteId)
        {
            Paciente paciente = _context.Paciente.Find(pacienteId);
            _context.Paciente.Remove(paciente);
        }

        public Paciente GetPacienteByID(int? pacienteId)
        {
            return _context.Paciente.Find(pacienteId);
        }

        public List<Paciente> GetPacientes()
        {
            return _context.Paciente.ToList();
        }

        public void InsertPaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
        }

        public int Save()
        {
            return  _context.SaveChanges();            
        }

        public void UpdatePaciente(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
        }

        private bool disposed = false;

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
    }
}