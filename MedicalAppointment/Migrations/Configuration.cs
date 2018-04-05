namespace MedicalAppointment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalAppointment.Models.MedicalAppointmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MedicalAppointment.Models.MedicalAppointmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.TipoCitas.AddOrUpdate(
              p => p.Descripcion,
              new Models.TipoCita {  Descripcion = "Medicina General" },
              new Models.TipoCita { Descripcion = "Odontologia" },
              new Models.TipoCita { Descripcion = "Pediatria" },
              new Models.TipoCita { Descripcion = "Neurologia" }
            );
            context.UserModels.AddOrUpdate(              
                x => x.Nombre,
              new Models.UserModel { Nombre = "test", Rol = "user" },
              new Models.UserModel { Nombre = "testadmin", Rol = "Admin" }
            );
            context.Pacientes.AddOrUpdate(
              new Models.Paciente { PacienteId = 111380195, Nombre = "Alvaro Ugalde", Edad = 35, Sexo ="Masculino" },
              new Models.Paciente { PacienteId = 505020101, Nombre = "Juan Perez", Edad = 54, Sexo = "Masculino" }
            );
            context.Citas.AddOrUpdate(
              new Models.Cita { Id = 1, PacienteId = 111380195, Fecha = new DateTime(2018,5,5,12,0,0), TipoCitaId = 1},
              new Models.Cita { Id = 1, PacienteId = 111380195, Fecha = new DateTime(2018, 5, 12, 12, 0, 0), TipoCitaId = 2 }
            );
        }
    }
}
