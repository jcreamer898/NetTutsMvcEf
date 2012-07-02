using System.Web.Http;
using System.Web.Mvc;
using Reviewed.Controllers;
using Reviewed.Models;
using Reviewed.Models.Abstract;
using Reviewed.Models.Repos;
using Reviewed.Plumbing;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Reviewed.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Reviewed.App_Start.NinjectWebCommon), "Stop")]

namespace Reviewed.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();
            kernel.Bind<ICategoriesRepository>().To<CategoriesRepository>();
            kernel.Bind<ICommentsRepository>().To<CommentsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }        
    }
}
