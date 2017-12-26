using MVC4ServicesBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data
{
    public interface IUserRepository
    {
        void SaveUser(Guid userId, string firstname, string lastname);
        User GetUser(Guid userId);
    }
}
