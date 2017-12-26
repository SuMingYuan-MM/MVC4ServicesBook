using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4ServicesBook.Data;
using MVC4ServicesBook.Web.Api.Models;
using MVC4ServicesBook.Web.Api.TypeMappers;
using MVC4ServicesBook.Web.Common.Security;

namespace MVC4ServicesBook.Web.Api
{
    public class UserManager : IUserManager
    {
        private readonly IMembershipInfoProvider _membershipInfoProvider;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public User CreateUser(string username, string password, string firstname, string lastname, string email)
        {
            throw new NotImplementedException();
        }
    }
}