using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAppointment.Controllers;
using MedicalAppointment.Models;

namespace MedicalAppointmentAPI.Tests
{
    [TestClass]
    public class TestCitaController
    {
        [TestMethod]
        public void GetAllPacientes_ShouldReturnAllPacientes()
        {
            var testProducts = GetTestPacientes();
            var controller = new PacientesController();

            var result = controller.GetPacientes() as List<Paciente>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
        [TestMethod]
        public void GetPaciente_ShouldReturnCorrectPaciente()
        {
            var testProducts = GetTestPacientes();
            var controller = new PacientesController();

            var result = controller.GetPaciente(1) as OkNegotiatedContentResult<Paciente>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[1].Nombre, result.Content.Nombre);
        }
        [TestMethod]
        public void GetPaciente_ShouldNotFindPaciente()
        {
            var controller = new PacientesController();

            var result = controller.GetPaciente(0);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Paciente> GetTestPacientes()
        {
            var testPaciente = new List<Paciente>();
            testPaciente.Add(new Paciente { Id = 1, Nombre = "Alvaro Ugalde", Edad = 35, Sexo = "Masculino" });
            testPaciente.Add(new Paciente { Id = 2, Nombre = "Carlos Alvarado", Edad = 41, Sexo = "Masculino"});
        

            return testPaciente;
        }

    }
}
