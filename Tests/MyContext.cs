using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    
    public class MyContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        
    }
}
