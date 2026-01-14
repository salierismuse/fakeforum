using FakeForum.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FakeForum.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<FThread> FThreads { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

    }
}
