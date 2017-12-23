using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC4ServicesBook.Data.Model;


namespace MVC4ServicesBook.Web.Api.HttpFetchers
{
    public interface IHttpTaskFetcher
    {
        Task GetTask(long taskId);
    }
}
