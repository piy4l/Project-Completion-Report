using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }

    }
}
