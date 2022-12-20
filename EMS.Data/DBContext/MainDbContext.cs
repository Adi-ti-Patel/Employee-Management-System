using EMS.Model;
using Microsoft.EntityFrameworkCore;

namespace EMS.DBContext
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
