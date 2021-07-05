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
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<BattleGroup> BattleGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<BattleGroupUser> BattleGroupsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Description = "Atleta a 11 anos", Email = "rafael.ffs@hotmail.com", Name = "Rafael", Nickname = "Fashola", Password = "teste123" },
                new User { Id = 2, Description = "Atleta a 10 anos", Email = "gabriel@hotmail.com", Name = "Gabriel", Nickname = "Bibi", Password = "teste123" },
                new User { Id = 3, Description = "Atleta a 09 anos", Email = "iago@hotmail.com", Name = "Iago", Nickname = "Pedalantis", Password = "teste123" }
                );

            modelBuilder.Entity<BattleGroupUser>()
                 .HasKey(bgu => new { bgu.UserId, bgu.BattleGroupId });
            modelBuilder.Entity<BattleGroupUser>()
                .HasOne(bgu => bgu.User)
                .WithMany(u => u.BattleGroupUsers)
                .HasForeignKey(bgu => bgu.UserId);
            modelBuilder.Entity<BattleGroupUser>()
                .HasOne(bgu => bgu.BattleGroup)
                .WithMany(bg => bg.BattleGroupUsers)
                .HasForeignKey(bgu => bgu.BattleGroupId);
        }


    }
}
