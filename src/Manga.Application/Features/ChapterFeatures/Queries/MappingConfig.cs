using AutoMapper;
using Manga.Application.Dto;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.ChapterFeatures.Queries
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MangaChapter, MangaChapterDto>().ReverseMap();
        }
    }
}
