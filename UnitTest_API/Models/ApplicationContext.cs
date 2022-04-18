using Microsoft.EntityFrameworkCore;

namespace UnitTest_API.Models
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext>  options):base(options)
        {
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
