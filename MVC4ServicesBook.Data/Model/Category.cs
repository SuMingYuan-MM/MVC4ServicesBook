using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data.Model
{
<<<<<<< HEAD
    public class Category:IVersionedModelObject
=======
    public class Category
>>>>>>> 8efa8a90410547de06a68807e5454b5c951c050b
    {
        public virtual long CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
