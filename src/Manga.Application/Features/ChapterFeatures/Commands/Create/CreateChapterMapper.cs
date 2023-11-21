using AutoMapper;
using Manga.Domain.Entities;

namespace Manga.Application.Features.ChapterFeatures.Commands.Create
{
    public class CreateChapterMapper : Profile
    {
        public CreateChapterMapper()
        {
            CreateMap<CreateChapterCommand, MangaChapter>().ReverseMap();
        }
    }
}
