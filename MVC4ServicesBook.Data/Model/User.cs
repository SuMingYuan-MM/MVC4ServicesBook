using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data.Model
{
<<<<<<< HEAD
    public class User:IVersionedModelObject
=======
    public class User
>>>>>>> 8efa8a90410547de06a68807e5454b5c951c050b
    {
        public virtual Guid UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
<<<<<<< HEAD
        public virtual string UserName { get; set; }
=======
        public virtual string UserNamme { get; set; }
>>>>>>> 8efa8a90410547de06a68807e5454b5c951c050b
        public virtual string Email { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
