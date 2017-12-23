﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FluentNHibernate.Cfg.Db;
using log4net;
using MVC4ServicesBook.Common;
using MVC4ServicesBook.Web.Common;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Activation;
using MVC4ServicesBook.Data.SqlServer;
using MVC4ServicesBook.Web.Api.HttpFetchers;

namespace MVC4ServicesBook.Web.Api
{
    /// <summary>
    /// Class use to set up the Ninject DI container
    /// </summary>
    public class NinjectConfigurator
    {
        /// <summary>
        /// Entry method used by caller to configure the given
        /// container with all of this application's 
        /// dependencies. Also configures the container as this
        /// application's dependency resolver.
        /// </summary>
        /// <param name="container"></param>
        public void Configure(IKernel container)
        {
            // Add all binding/dependencies
            AddBindings(container);

            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private void AddBindings(IKernel container)
        {
            ConfigureNHibernate(container);

            ConfigureLog4net(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>();

            container.Bind<IHttpCategoryFetcher>().To<HttpCategoryFetcher>();
            container.Bind<IHttpPriorityFetcher>().To<HttpPriorityFetcher>();
            container.Bind<IHttpStatusFetcher>().To<HttpStatusFetcher>();
            container.Bind<IHttpUserFetcher>().To<HttpUserFetcher>();
            container.Bind<IHttpTaskFetcher>().To<HttpTaskFetcher>();

            container.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>();


            throw new NotImplementedException();
        }

        /// <summary>
        /// Set up log4Net for this application, including putting it in the 
        /// given container
        /// </summary>
        /// <param name="container"></param>
        private void ConfigureLog4net(IKernel container)
        {
            log4net.Config.XmlConfigurator.Configure();
            var loggerForWebSite = LogManager.GetLogger("Mvc4ServicesBookWebsite");
            container.Bind<ILog>().ToConstant(loggerForWebSite);
        }

        /// <summary>
        /// Set up NHibernate, and adds an ISessionFactory to the given
        /// </summary>
        /// <param name="container"></param>
        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = FluentNHibernate
                .Cfg.Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        c => c.FromConnectionStringWithKey("Mvc4ServicesDb")
                    ))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SqlCommandFactory>())
                .BuildSessionFactory();

            // Add the ISessionFactory instance to the container
            container.Bind<ISessionFactory>().ToConstant(sessionFactory);

            // Configure a resolver method to be used for creating ISession method
            container.Bind<ISession>().ToMethod(CreateSession);

            container.Bind<ICurrentSessionContextAdapter>().To<CurrentSessionContextAdapter>();
        }

        /// <summary>
        /// Method used to create instance of ISession objects
        /// and bind them to HTTP context
        /// </summary>
        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                // Open new ISession and bind it to the current session context
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }
    }
}