using Microsoft.EntityFrameworkCore;
using SchoolCRUDAPP.Models;

namespace SchoolCRUDAPP
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
