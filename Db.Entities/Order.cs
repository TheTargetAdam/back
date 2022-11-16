using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Entities.CommonBase;
using rewriter.Shared.Common.Enums;
namespace Db.Entities
{
    public class Order
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string topic { get; set; }
        public decimal cost { get; set; }
        public string period { get; set; }
        public StatusOrderEnum status { get; set; }
        public int CreatorId { get; set; }
        public virtual User User{ get; set; }

    }
}
