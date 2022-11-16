using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Entities.CommonBase;
namespace Db.Entities
{
    public enum UserType
    {
        Creator,
        Performer
    }
    public  class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public virtual ICollection<Order> Orders { get; set;}

    }
}
