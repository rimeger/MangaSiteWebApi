using Manga.Models;
using Microsoft.EntityFrameworkCore;

namespace Manga.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<MangaTitle> MangaTitles { get; set; }
        DbSet<MangaChapter> MangaChapters { get; set; }
        DbSet<MangaPage> MangaPages { get; set; }

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
