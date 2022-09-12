using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;

namespace task.Data
{
    public class BContext: IdentityDbContext<ApplicationUser>
    {
        IConfiguration configuration;
        public BContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Nationality> Nationalities { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<Book> Books { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connecttion"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
