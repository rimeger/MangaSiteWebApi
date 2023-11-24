﻿using Manga.Domain.Common;

namespace Manga.Domain.Entities
{
    public class MangaTitle : BaseEntity
    {
        public string TitleName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public ICollection<MangaChapter> Chapters { get; set; } = new List<MangaChapter>();
    }
}
