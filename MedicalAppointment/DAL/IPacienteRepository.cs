using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MedicalAppointment.Models;
using System.Threading.Tasks;

namespace MedicalAppointment.DAL
{
    public interface IPacienteRepository:IDisposable
    {
        List<Paciente> GetPacientes();
        
        Paciente GetPacienteByID(int? pacienteId);
        void InsertPaciente(Paciente paciente);
        void DeletePaciente(int? pacienteId);
        void UpdatePaciente(Paciente paciente);
        int Save();
    }
}