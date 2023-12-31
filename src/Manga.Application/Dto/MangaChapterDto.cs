﻿namespace Manga.Application.Dto
{
    public class MangaChapterDto
    {
        public Guid Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
