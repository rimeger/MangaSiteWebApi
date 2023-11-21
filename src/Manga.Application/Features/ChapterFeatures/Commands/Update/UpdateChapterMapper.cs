using AutoMapper;

using Manga.Domain.Entities;

namespace Manga.Application.Features.ChapterFeatures.Commands.Update
{
    public class UpdateChapterMapper : Profile
    {
        public UpdateChapterMapper()
        {
            CreateMap<UpdateChapterCommand, MangaChapter>().ReverseMap();
        }
    }
}
