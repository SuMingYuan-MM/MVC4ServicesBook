using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC4ServicesBook.Data.Model
{
    public class Task
    {
        public virtual long TaskId { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime DateCompleted { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual byte[] TimeStamp { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public readonly IList<User> _users = new List<User>();
        public virtual IList<User> Users { get { return _users; } }
        public readonly IList<Category> _categories = new List<Category>();
        public virtual IList<Category> Categories { get { return _categories; } }
    }
}
