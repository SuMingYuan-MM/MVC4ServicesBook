using System.Web;
using System.Web.Http;
using Antlr.Runtime.Misc;


namespace MVC4ServicesBook.Web.Api
{
    using System;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon
    {
        static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Start the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stop the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx=>()=>new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            var containerConfigurator = new NinjectConfigurator();
            containerConfigurator.Configure(kernel);

            GlobalConfiguration.Configuration.MessageHandlers.Add(kernel.Get<BasicAuthenticationMessageHandler>());
        }
    }
}