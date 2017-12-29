using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public class PriorityMapper:IPriorityMapper
    {
        public Priority CreatePriority(Data.Model.Priority priority)
        {
            return new Priority
            {
                PriorityId = priority.PriorityId,
                Name = priority.Name,
                Ordinal = priority.Ordinal,
                Links = new List<Link>
                {
                    new Link
                    {
                        Title = "self",
                        Rel = "self",
                        Href = "/api/priorities/"+priority.PriorityId
                    },
                    new Link
                    {
                        Title = "self",
                        Rel = "self",
                        Href = "/api/priorities"
                    }
                }
            };
        }
    }
}