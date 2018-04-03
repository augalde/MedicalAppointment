using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace MedicalAppointment.Models
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext() : base("name=RepositoryContext")
        {
        }

        public System.Data.Entity.DbSet<MedicalAppointment.Models.Paciente> Paciente { get; set; }

        public System.Data.Entity.DbSet<MedicalAppointment.Models.TipoCita> TipoCita { get; set; }

        public System.Data.Entity.DbSet<MedicalAppointment.Models.Cita> Cita { get; set; }
    }
}