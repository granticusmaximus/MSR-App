using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp
{
    public class MSRDbContext : DbContext
    {
        public MSRDbContext(DbContextOptions<MSRDbContext> options)
            : base(options)
        { }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Analyst> Analysts { get; set; }
        public DbSet<AppList> Apps { get; set; }
        public DbSet<MSRTask> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}