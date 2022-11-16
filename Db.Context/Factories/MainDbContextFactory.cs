using Db.Context.Context;
using Microsoft.EntityFrameworkCore;
namespace Db.Context.Factories
{
    public class MainDbContextFactory
    {
        private readonly DbContextOptions<MainDbContext> options;

        public MainDbContextFactory( DbContextOptions<MainDbContext> options)
        {
            this.options = options;
        }
        public MainDbContext Create()
        {
            return new MainDbContext(options);
        }
        
    }
}
