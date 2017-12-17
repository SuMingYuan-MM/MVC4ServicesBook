using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ninject;
using  Ninject.Web.Common;

#pragma warning disable 1587

namespace MVC4ServicesBook.Web.Api.App_Start
{
    /// <summary>
    /// Class used to set up the Ninject DI container
    /// </summary>
    public class NinjectConfigurator
    {
        ///<summary>
        /// Entry method used by caller to configure the given
        /// container with all of this application's 
        /// dependencies. Also configures the container as this
        /// application's dependency resolver.
        /// </summary>
        public void Configure(IKernel container)
        {
            //Add all bindings/dependencies
            AddBindings(container);

            //Use the container and our NinjectDependencyResolver as
            //application's resolver
            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Add all bindings/dependencies to the container
        /// </summary>
        /// <param name="container"></param>
        private void AddBindings(IKernel container)
        {
            ConfigureNHibernate(container);

            throw new NotImplementedException();
        }

        private void ConfigureNHibernate(IKernel container)
        {
            throw new NotImplementedException();
        }
    }
}