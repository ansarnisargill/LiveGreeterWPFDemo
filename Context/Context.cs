using Microsoft.EntityFrameworkCore;

namespace LiveGreeterWpfDemo
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


        
    }
}
