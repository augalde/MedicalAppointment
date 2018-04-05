using MedicalAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalAppointment.DAL
{
    public class TipoCitaRepository:ITipoCitaRepository, IDisposable
    {
        private RepositoryContext _context;

        public TipoCitaRepository(RepositoryContext context)
        {
            this._context = context;
        }
        public List<TipoCita> GetTipoCitas()
        {
            return _context.TipoCita.ToList();
        }

        public TipoCita GetTipoCitaByID(int? tipoCitaId)
        {
            return _context.TipoCita.Find(tipoCitaId);
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