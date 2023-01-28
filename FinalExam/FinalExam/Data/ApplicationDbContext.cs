using FinalExam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
