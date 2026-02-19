using Microsoft.EntityFrameworkCore;
using KohanovMaximLB_295.Models;
using System.Collections.Generic;

namespace KohanovMaximLB_295.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EpsteinEntry> EpsteinEntries { get; set; }
    }
}

