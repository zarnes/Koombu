using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{

    public class DbAPIContext : DbContext
    {
        // Create tables with entity framework
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Group> User_Groups { get; set; }

        public DbAPIContext(DbContextOptions<DbAPIContext> options) : base(options) { }

        public DbAPIContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=(localdb)\mssqllocaldb;Database=Koombu;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}
