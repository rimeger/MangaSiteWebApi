﻿namespace Manga.Models
{
    public class MangaChapter : BaseEntity
    {
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public MangaTitle MangaTitle { get; set; }
        public ICollection<MangaPage> Pages { get; set; } = new List<MangaPage>();
    }
}
