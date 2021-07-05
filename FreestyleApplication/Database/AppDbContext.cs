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
        //public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Description = "Atleta a 11 anos", Email = "rafael.ffs@hotmail.com", Name = "Rafael", Nickname = "Fashola", Password = "teste123" },
                new User { Id = 2, Description = "Atleta a 10 anos", Email = "gabriel@hotmail.com", Name = "Gabriel", Nickname = "Bibi", Password = "teste123" },
                new User { Id = 3, Description = "Atleta a 09 anos", Email = "iago@hotmail.com", Name = "Iago", Nickname = "Pedalantis", Password = "teste123" }
                );

            //        modelBuilder.Entity<GroupUser>()
            //.HasKey(gu => new { gu.GroupId, gu.UserId });
            //        modelBuilder.Entity<GroupUser>()
            //            .HasOne(gu => gu.Group)
            //            .WithMany(b => b.GroupUser)
            //            .HasForeignKey(gu => gu.GroupId);
            //        modelBuilder.Entity<GroupUser>()
            //            .HasOne(gu => gu.User)
            //            .WithMany(c => c.GroupUsers)
            //            .HasForeignKey(gu => gu.CategoryId);
            //
        }


    }
}
