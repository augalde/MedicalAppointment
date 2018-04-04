using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MedicalAppointment.Models;

namespace MedicalAppointment.DAL
{
    public interface ICitaRepository : IDisposable
    {
        List<Cita> GetCitas();

        Cita GetCitaByID(int? citaId);
        void InsertCita(Cita cita);
        void DeleteCita(int? citaId);
        void UpdateCita(Cita cita);
        int Save();
    }
}