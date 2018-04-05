using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalAppointment.Models;

namespace MedicalAppointment.DAL
{
    public class UserRepository: IUserRepository, IDisposable
    {

        private RepositoryContext _context;

        public UserRepository(RepositoryContext context)
        {
            this._context = context;
        }
        public List<UserModel> GetUsers()
        {
            return _context.User.ToList();
        }

        public UserModel GetUserByID(int? userId)
        {
            return _context.User.Find(userId);
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