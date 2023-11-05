﻿using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Create
{
    public record CreateTitleCommand : IRequest
    {
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
    }
}