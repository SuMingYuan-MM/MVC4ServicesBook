using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC4ServicesBook.Data.Model;

namespace MVC4ServicesBook.Web.Api.HttpFetchers
{
    public interface IHttpStatusFetcher
    {
        Status GetStatus(long statusId);
    }
}
