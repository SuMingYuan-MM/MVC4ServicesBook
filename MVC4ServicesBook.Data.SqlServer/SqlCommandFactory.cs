using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace MVC4ServicesBook.Data.SqlServer
{
    public class SqlCommandFactory:ISqlCommandFactory
    {
        private readonly ISession _sessoin;

        public SqlCommandFactory(ISession session)
        {
            _sessoin = session;
        }

        public SqlCommand GetCommand()
        {
            var connection = GetOpenConnection();
            var command = (SqlCommand) connection.CreateCommand();

            if (_sessoin.Transaction !=  null)
            {
                _sessoin.Transaction.Enlist(command);
            }
            return command;
        }

        private IDbConnection GetOpenConnection()
        {
            var connection = _sessoin.Connection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
