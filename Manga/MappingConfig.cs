using AutoMapper;
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
        }
    }
}
