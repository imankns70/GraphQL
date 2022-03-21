using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                            .HasMany(p => p.Commands)
                            .WithOne(c => c.Platform)
                            .HasForeignKey(a => a.PlatformId);

            modelBuilder.Entity<Command>()
                .HasOne(c => c.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(a => a.PlatformId);
        }

    }
}
