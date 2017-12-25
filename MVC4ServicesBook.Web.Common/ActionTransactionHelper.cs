using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using NHibernate;

namespace MVC4ServicesBook.Web.Common
{
    public class ActionTransactionHelper:IActionTransactionHelper
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ICurrentSessionContextAdapter _currentSessionContextAdapter;

        public ActionTransactionHelper(
            ISessionFactory sessionFactory, 
            ICurrentSessionContextAdapter currentSessionContextAdapter)
        {
            _sessionFactory = sessionFactory;
            _currentSessionContextAdapter = currentSessionContextAdapter;
        }

        public bool TransactionHandled { get; private set; }
        public bool SessionClosed { get; private set; }

        public void BeginTransaction()
        {
            var session = _sessionFactory.GetCurrentSession();
            if (session != null)
            {
                session.BeginTransaction();
            }
        }

        public void EndTransaction(HttpActionExecutedContext filterContext)
        {
            var session = _sessionFactory.GetCurrentSession();
            if(session==null) return;
            if(!session.Transaction.IsActive) return;

            if (filterContext.Exception == null)
            {
                session.Flush();
                session.Transaction.Commit();
            }
            else
            {
                session.Transaction.Rollback();
            }
            TransactionHandled = true;
        }

        public void CloseSession()
        {
            if (_currentSessionContextAdapter.HasBind(_sessionFactory))
            {
                var session = _sessionFactory.GetCurrentSession();
                session.Close();
                session.Dispose();
                _currentSessionContextAdapter.Unbind(_sessionFactory);

                SessionClosed = true;
            }
        }
    }
}
