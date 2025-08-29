using Ninject.Web.Common.WebHost;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using _2_Library_Interface.Interfaces;
using _3_Library_Repository.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Nursery_Management.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Nursery_Management.App_Start.NinjectWebCommon), "Stop")]
namespace Nursery_Management.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            try
            {
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<Library_Book_Interface>().To<Library_Book_Repository>();

            kernel.Bind<Login_Interface>().To<Login_Repository>();


           

        }
    }
}