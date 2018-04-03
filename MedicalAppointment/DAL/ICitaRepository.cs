using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MedicalAppointment.Models;

namespace MedicalAppointment.DAL
{
    public interface ICitaRepository
    {
        List<Cita> GetCitas();

        Cita GetPacienteByID(int? citaId);
        void InsertCita(Cita cita);
        void DeleteCita(int? cita);
        void UpdateCita(Cita cita);
        int Save();
    }
}