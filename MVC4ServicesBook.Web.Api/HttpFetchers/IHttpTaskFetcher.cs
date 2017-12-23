using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MVC4ServicesBook.Data.Model.Task;

namespace MVC4ServicesBook.Web.Api.HttpFetchers
{
    public interface IHttpTaskFetcher
    {
        Task GeTask(long taskId);
    }
}
