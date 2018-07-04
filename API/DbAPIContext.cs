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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<User_Group> User_Groups { get; set; }

        public DbAPIContext(DbContextOptions<DbAPIContext> options) : base(options) { }
    }
}
