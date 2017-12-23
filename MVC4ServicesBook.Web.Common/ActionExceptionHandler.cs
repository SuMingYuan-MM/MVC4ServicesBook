using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MVC4ServicesBook.Web.Common
{
    public class ActionExceptionHandler:IActionExceptionHandler
    {
        public const int MaxStatusDescriptionLength = 512;

        public void HandleException(HttpActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
