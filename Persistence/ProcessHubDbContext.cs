using Microsoft.EntityFrameworkCore;
using ProcessHub.Core.Models;

namespace ProcessHub.Persistence
{
    public class ProcessHubDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public ProcessHubDbContext(DbContextOptions<ProcessHubDbContext> options)
      : base(options)
        {
        }
    }
}