using EmployeePortalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortalApi.Data
{
    public class EmployeePortalContext : DbContext
    {
        public EmployeePortalContext(DbContextOptions<EmployeePortalContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }

}
