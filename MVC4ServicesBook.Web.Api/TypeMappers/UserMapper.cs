using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public class UserMapper:IUserMapper
    {
        public User CreateUser(string username, string firstname, string lastname, string email, Guid userId)
        {
            return new User
            {
                UserId = userId,
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Links = new List<Link>
                {
                    new Link
                    {
                        Title = "self",
                        Rel = "self",
                        Href = "/api/users/"+userId
                    },
                    new Link
                    {
                        Title = "All Users",
                        Rel = "all",
                        Href = "/api/users"
                    }
                }
            };
        }

        public User CreateUser(Data.Model.User modelUser)
        {
            return CreateUser(
                modelUser.UserNamme,
                modelUser.FirstName,
                modelUser.LastName,
                modelUser.Email,
                modelUser.UserId);
        }
    }
}