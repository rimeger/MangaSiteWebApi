﻿using Manga.Application.Abstractions;
using Manga.Domain.Entities;
using Manga.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Manga.Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IPasswordHasher passwordHasher) : base(options)
        {
            var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreater != null)
            {
                if (!dbCreater.CanConnect())
                {
                    dbCreater.Create();
                }

                if (!dbCreater.HasTables())
                {
                    dbCreater.CreateTables();
                }
            }
        }

        public DbSet<MangaTitle> MangaTitles { get; set; }
        public DbSet<MangaChapter> MangaChapters { get; set; }
        public DbSet<MangaPage> MangaPages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChapter> UserChapters { get; set; }
        public DbSet<UserTitle> UserTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MangaTitle>()
                .HasKey(mt => mt.Id);
            modelBuilder.Entity<MangaTitle>()
                .HasMany(mt => mt.Chapters)
                .WithOne(mt => mt.MangaTitle)
                .HasForeignKey("MangaTitleId")
                .IsRequired();
            modelBuilder.Entity<MangaChapter>()
                .HasKey(mc => mc.Id);
            modelBuilder.Entity<MangaChapter>()
                .HasMany(mc => mc.Pages)
                .WithOne(mc => mc.MangaChapter)
                .HasForeignKey("MangaChapterId")
                .IsRequired();
            modelBuilder.Entity<MangaPage>()
                .HasKey(mp => mp.Id);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasData(new User
                { 
                    Id = Guid.Parse("5A2C4E8B-9D1F-4A7B-A0C8-8D9B6F2E3A14"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserName = "admin",
                    Email = "admin@admin.com",
                    Password = new PasswordHasher().Hash("!@#$%^&*(admin)1128"),
                    Role = "Admin"
                }
                );
            modelBuilder.Entity<UserChapter>()
                .HasKey(uc => new { uc.ChapterId, uc.UserId });
            modelBuilder.Entity<UserChapter>()
                .HasOne(mc => mc.MangaChapter)
                .WithMany(uc => uc.UserChapters)
                .HasForeignKey(mc => mc.ChapterId);
            modelBuilder.Entity<UserChapter>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserChapters)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserTitle>()
                .HasKey(ut => new { ut.TitleId, ut.UserId });
            modelBuilder.Entity<UserTitle>()
                .HasOne(mt => mt.MangaTitle)
                .WithMany(ut => ut.UserTitles)
                .HasForeignKey(mt => mt.TitleId);
            modelBuilder.Entity<UserTitle>()
                .HasOne(u => u.User)
                .WithMany(ut => ut.UserTitles)
                .HasForeignKey(u => u.UserId);
        }
    }
}
