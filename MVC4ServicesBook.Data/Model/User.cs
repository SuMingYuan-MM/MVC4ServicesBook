using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data.Model
{
    public class User
    {
        public virtual Guid UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserNamme { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
