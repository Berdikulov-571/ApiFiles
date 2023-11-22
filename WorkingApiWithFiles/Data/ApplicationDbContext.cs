using Microsoft.EntityFrameworkCore;
using WorkingApiWithFiles.Entities;

namespace WorkingApiWithFiles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
