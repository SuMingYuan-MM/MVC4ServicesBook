using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public interface IUserMapper
    {
        User CreateUser(string username, string firstname, string lastname, string email, Guid userId);
        User CreateUser(Data.Model.User modelUser);
    }
}
