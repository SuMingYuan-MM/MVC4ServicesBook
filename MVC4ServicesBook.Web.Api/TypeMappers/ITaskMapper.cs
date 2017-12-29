using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MVC4ServicesBook.Web.Api.Models.Task;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public interface ITaskMapper
    {
        Task CreateTask(Data.Model.Task task);
    }
}
