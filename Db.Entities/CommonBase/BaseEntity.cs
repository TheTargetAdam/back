using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Entities.CommonBase
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Microsoft.EntityFrameworkCore.Index("Uid", IsUnique = true)]
    public abstract class BaseEntity
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        //[Required]
        public  Guid Uid { get; set; }
    }
}
