using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Web.Common.Security
{
    public interface IMembershipInfoProvider
    {
        MembershipUserWrapper GetUser(string username);
        MembershipUserWrapper GetUser(Guid userId);
        MembershipUserWrapper CreateUser(string username, string password, string email);
        bool ValidateUser(string username, string password);
        string[] GetRolesForUser(string username);
    }
}
