using MVC4ServicesBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Web.Api.HttpFetchers
{
    public interface IHttpCategoryFetcher
    {
        Category GetCategory(long categoryId);
    }
}
