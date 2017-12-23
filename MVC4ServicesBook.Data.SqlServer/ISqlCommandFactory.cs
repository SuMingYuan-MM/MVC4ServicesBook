using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data.SqlServer
{
    public interface ISqlCommandFactory
    {
        SqlCommand GetCommand();
    }
}
