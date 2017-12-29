using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public class StatusMapper:IStatusMapper
    {
        public Status CreatedStatus(Data.Model.Status status)
        {
            return new Status
            {
                StatusId = status.StatusId,
                Name = status.Name,
                Ordinal = status.Ordinal,
                Links = new List<Link>
                {
                    new Link
                    {
                        Title = "self",
                        Rel = "self",
                        Href = "/api/statuses/" + status.StatusId
                    },
                    new Link
                    {
                        Title = "self",
                        Rel = "self",
                        Href = "/api/statuses"
                    }
                }
            };
        }
    }
}