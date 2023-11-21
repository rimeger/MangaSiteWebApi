using Manga.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manga.Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MangaTitle> MangaTitles { get; set; }
        public DbSet<MangaChapter> MangaChapters { get; set; }
        public DbSet<MangaPage> MangaPages { get; set; }

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
        }
    }
}
