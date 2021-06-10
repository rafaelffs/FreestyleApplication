using FreestyleApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Description = "Atleta a 11 anos", Email = "rafael.ffs@hotmail.com", Name = "Rafael", Nickname = "Fashola", Password = "teste123" },
                new User { Id = 2, Description = "Atleta a 10 anos", Email = "gabriel@hotmail.com", Name = "Gabriel", Nickname = "Bibi", Password = "teste123" },
                new User { Id = 3, Description = "Atleta a 09 anos", Email = "iago@hotmail.com", Name = "Iago", Nickname = "Pedalantis", Password = "teste123" }
                );
        }

        public DbSet<FreestyleApplication.Models.Competition> Competition { get; set; }
    }
}
