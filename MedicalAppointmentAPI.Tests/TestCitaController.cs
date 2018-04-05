using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAppointment.Controllers;
using MedicalAppointment.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using MedicalAppointment.DAL;
using Moq;
using System.Data.Entity;

namespace MedicalAppointmentAPI.Tests
{
    [TestClass]
    public class TestCitaController
    {
        [TestMethod]
        public void TestGetAllUsers()
        {
           // //Arrange
           // Cita varCita1 = new Cita { Id = 1, PacienteId = 111380195, Fecha = new DateTime(), TipoCitaId = 1 };
           // //var mock = new Mock<DbContext>();
           // //mock.Setup(x => x.Set<Cita>())
           // //    .Returns(new FakeDbSet<Cita>
           // //    {
           // //new Cita { Id = 1, PacienteId = 111380195, Fecha = new DateTime(), TipoCitaId = 1}
           // //    });

           // var userDbSet = new FakeDbSet<Cita>();
           // userDbSet.Add(varCita1);

           // var contextMock = new Mock<RepositoryContext>();
           // contextMock.Setup(dbContext => dbContext.Cita).Returns(userDbSet);

           //// UserService userService = new UserService(mock.Object);

           // // Act
           // var allUsers = userService.GetAllUsers();

           // // Assert
           // Assert.AreEqual(1, allUsers.Count());
        }

        [TestMethod]
        public void Test_INSERT_And_Retrieve_Cita()
        {
            // Arrange
            Cita cita1 = new Cita { Id = 1, PacienteId = 111380195, Fecha = new DateTime(), TipoCitaId = 1};

            ICitaRepository citaRepository  = new CitaRepository(new RepositoryContext());

            citaRepository.InsertCita(cita1);
            var controller = new CitasController(citaRepository);
            
            // Act
            var result = controller.GetCita(1);

            // 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_INSERT_And_Retrieve_CitabyId()
        {
            // Arrange
            Cita cita1 = new Cita { Id = 123, PacienteId = 111380195, Fecha = new DateTime(), TipoCitaId = 1 };

            ICitaRepository citaRepository = new CitaRepository(new RepositoryContext());
            
            citaRepository.InsertCita(cita1);
            var controller = new CitasController(citaRepository);

            // Act
            var result = controller.GetCita(123);
            var citaResult = result as OkNegotiatedContentResult<Cita>;
            

            // 
            Assert.Equals(citaResult.Content.PacienteId, 111380195);
        }

        //[TestMethod]
        //public void GetReturnsPaciente()
        //{
        //    // Arrange
        //    var controller = new PacientesController();
        //    controller.Request = new HttpRequestMessage();
        //    controller.Configuration = new HttpConfiguration();

        //    // Act
        //    Paciente paciente = controller.GetPaciente(1) as Paciente;

        //    // Assert

        //    ;
        //    Assert.AreEqual("Alvaro Ugalde", paciente.Nombre);
        //}

        //[TestMethod]
        //public void PostSetsLocationHeader()
        //{
        //    // Arrange
        //    PacientesController controller = new PacientesController();

        //    controller.Request = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("http://localhost/api/pacientes")
        //    };
        //    controller.Configuration = new HttpConfiguration();
        //    controller.Configuration.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional });

        //    controller.RequestContext.RouteData = new HttpRouteData(
        //        route: new HttpRoute(),
        //        values: new HttpRouteValueDictionary { { "controller", "pacientes" } });

        //    // Act
        //    Paciente paciente = new Paciente() { Nombre = "Juan Perez",Edad=5,Sexo="Masculino" };
        //    var response = controller.PostPaciente(paciente);

        //    // Assert
        //    //Assert.AreEqual("http://localhost/api/paciente/3", response.Headers.Location.AbsoluteUri);
        //}

        //[TestMethod]
        //public void GetAllPacientes_ShouldReturnAllPacientes()
        //{
        //    var testProducts = GetTestPacientes();
        //    var controller = new PacientesController();

        //    var result = controller.GetPacientes() as List<Paciente>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}
        //[TestMethod]
        //public void GetPaciente_ShouldReturnCorrectPaciente()
        //{
        //    var testProducts = GetTestPacientes();
        //    var controller = new PacientesController();

        //    var result = controller.GetPaciente(1) as OkNegotiatedContentResult<Paciente>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testProducts[1].Nombre, result.Content.Nombre);
        //}
        //[TestMethod]
        //public void GetPaciente_ShouldNotFindPaciente()
        //{
        //    var controller = new PacientesController();

        //    var result = controller.GetPaciente(0);
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        //private List<Paciente> GetTestPacientes()
        //{
        //    var testPaciente = new List<Paciente>();
        //    testPaciente.Add(new Paciente { PacienteId = 1, Nombre = "Alvaro Ugalde", Edad = 35, Sexo = "Masculino" });
        //    testPaciente.Add(new Paciente { PacienteId = 2, Nombre = "Carlos Alvarado", Edad = 41, Sexo = "Masculino"});


        //    return testPaciente;
        //}

    }
}
