using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using log4net;

namespace MVC4ServicesBook.Web.Common
{
    public class ActionLogHelper:IActionLogHelper
    {
        private const string EnteringText = "ENTERING";
        private const string ExitingText = "EXITING";
        private const string LogTextFormatString = "{0} {1}:{2}";

        private readonly ILog _logger;

        public ActionLogHelper(ILog logger)
        {
            _logger = logger;
        }
        public void LogEntry(HttpActionDescriptor actionDescriptor)
        {
            LogAction(actionDescriptor, EnteringText);
        }

        public void LogExit(HttpActionDescriptor actionDescriptor)
        {
            LogAction(actionDescriptor, ExitingText);
        }

        public void LogAction(HttpActionDescriptor actionDescriptor, string prefix)
        {
            _logger.DebugFormat(LogTextFormatString,
                prefix,
                actionDescriptor.ControllerDescriptor.ControllerType.FullName,
                actionDescriptor.ActionName);
        }
    }
}
