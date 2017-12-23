using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MVC4ServicesBook.Data.Model;
using NHibernate;

namespace MVC4ServicesBook.Web.Api.HttpFetchers
{
    public class HttpTaskFetcher:IHttpTaskFetcher
    {
        private readonly ISession _session;

        public HttpTaskFetcher(ISession session)
        {
            _session = session;
        }

        public Task GeTask(long taskId)
        {
            var task = _session.Get<Task>(taskId);
            if (task == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = string.Format("Task {0} not found.", taskId)
                    });
            }
            return task;
        }
    }
}