using AutoMapper;
using Manga.MediatR.MangaChapter.Commands.Create;
using Manga.MediatR.MangaChapter.Commands.Update;
using Manga.MediatR.MangaPage.Commands.Create;
using Manga.MediatR.MangaPage.Commands.Update;
using Manga.MediatR.MangaTitle.Commands.Create;
using Manga.MediatR.MangaTitle.Commands.Update;
using Manga.Models;
using Manga.Models.Dto;

namespace Manga
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MangaTitle, MangaTitleDto>().ReverseMap();
            CreateMap<MangaTitle, CreateTitleCommand>().ReverseMap();
            CreateMap<MangaTitle, UpdateTitleCommand>().ReverseMap();

            CreateMap<MangaChapter, MangaChapterDto>().ReverseMap();
            CreateMap<MangaChapter, CreateChapterCommand>().ReverseMap();
            CreateMap<MangaChapter, UpdateChapterCommand>().ReverseMap();

            CreateMap<MangaPage, MangaPageDto>().ReverseMap();
            CreateMap<MangaPage, CreatePageCommand>().ReverseMap();
            CreateMap<MangaPage, UpdatePageCommand>().ReverseMap();
        }
    }
}
