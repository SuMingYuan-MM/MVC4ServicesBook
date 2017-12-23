﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MVC4ServicesBook.Web.Common
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext filterContext);
    }
}