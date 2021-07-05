﻿// <auto-generated />
using System;
using FreestyleApplication.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreestyleApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BattleGroupUser", b =>
                {
                    b.Property<int>("BattleGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("BattleGroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BattleGroupUser");
                });

            modelBuilder.Entity("CompetitionUser", b =>
                {
                    b.Property<int>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CompetitionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CompetitionUser");
                });

            modelBuilder.Entity("FreestyleApplication.Models.BattleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("BattleGroups");
                });

            modelBuilder.Entity("FreestyleApplication.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("FreestyleApplication.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FreestyleApplication.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Atleta a 11 anos",
                            Email = "rafael.ffs@hotmail.com",
                            Name = "Rafael",
                            Nickname = "Fashola",
                            Password = "teste123"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Atleta a 10 anos",
                            Email = "gabriel@hotmail.com",
                            Name = "Gabriel",
                            Nickname = "Bibi",
                            Password = "teste123"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Atleta a 09 anos",
                            Email = "iago@hotmail.com",
                            Name = "Iago",
                            Nickname = "Pedalantis",
                            Password = "teste123"
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("BattleGroupUser", b =>
                {
                    b.HasOne("FreestyleApplication.Models.BattleGroup", null)
                        .WithMany()
                        .HasForeignKey("BattleGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreestyleApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompetitionUser", b =>
                {
                    b.HasOne("FreestyleApplication.Models.Competition", null)
                        .WithMany()
                        .HasForeignKey("CompetitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreestyleApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreestyleApplication.Models.BattleGroup", b =>
                {
                    b.HasOne("FreestyleApplication.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FreestyleApplication.Models.Group", b =>
                {
                    b.HasOne("FreestyleApplication.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("FreestyleApplication.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreestyleApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
