using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalAppointment.Models;

namespace MedicalAppointment.DAL
{
    public interface IUserRepository : IDisposable
    {
        List<UserModel> GetUsers();

        UserModel GetUserByID(int? userId);
    }
}