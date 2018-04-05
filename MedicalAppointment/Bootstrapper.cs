using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalAppointment.DAL;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Mvc5;
using MedicalAppointment.Models;
using Unity.Lifetime;

namespace MedicalAppointment
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<System.Data.Entity.DbContext, RepositoryContext>(new PerThreadLifetimeManager());
            
            container.RegisterType<ICitaRepository, CitaRepository>();


            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}