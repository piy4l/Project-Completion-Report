using Microsoft.EntityFrameworkCore;
using ProjectManagementMVC.Models;

namespace ProjectManagementMVC.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }

    }
}
