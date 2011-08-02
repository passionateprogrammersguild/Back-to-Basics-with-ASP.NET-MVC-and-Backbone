using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using SpeakerRating.Controllers;

namespace SpeakerRating
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "SpeakerRoute", // Route name
               "{controller}.aspx/{id}", // URL with parameters
               new { controller = "Speaker", action = "Speaker" } // Parameter defaults
           );

            routes.MapRoute(
               "Speakers", // Route name
               "{controller}.aspx", // URL with parameters
               new { controller = "Speaker", action = "Speakers" } // Parameter defaults
           );
            
            routes.MapRoute(
                "Default", // Route name
                "{controller}.aspx/{action}/{id}", // URL with parameters
                new { controller = "Speaker", action = "Speaker" } // Parameter defaults
            );

            routes.MapRoute(
                "Home", // Route name
                "", // URL with parameters
                new { controller = "Speaker", action = "Speakers" } // Parameter defaults
            );

        }

        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            builder.RegisterType<SpeakerService>();
            // ... continue registering dependencies and register your controllers...
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            // Set the controller factory using the container provider.
            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);          
        }
    }
}