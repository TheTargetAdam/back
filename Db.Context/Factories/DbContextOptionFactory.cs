using Db.Context.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Context.Factories
{
    public class DbContextOptionFactory
    {
        public static DbContextOptions<MainDbContext> Create(string connectionstring)
        {
             var builder=new DbContextOptionsBuilder<MainDbContext>();
            Configure(connectionstring).Invoke(builder);
            return builder.Options;
        }
        public static Action<DbContextOptionsBuilder> Configure(string connectionstring)
        {
            return (builder)=>
            builder.UseSqlServer(connectionstring);
        }
    }
}
