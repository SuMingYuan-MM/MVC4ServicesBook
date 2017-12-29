using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Web.Common.Security
{
    public interface IUserSession
    {
        Guid UserId { get; }
        string Firstname { get; }
        string Lastname { get; }
        string Username { get; }
        string Email { get; }
    }
}
