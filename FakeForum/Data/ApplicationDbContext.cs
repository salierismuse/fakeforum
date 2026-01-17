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
        public DbSet<Board> Boards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("boards");
            modelBuilder.Entity<AppUser>().ToTable("appusers");
            modelBuilder.Entity<FThread>().ToTable("fthreads");
            modelBuilder.Entity<Post>().ToTable("posts");
        }
    }
}