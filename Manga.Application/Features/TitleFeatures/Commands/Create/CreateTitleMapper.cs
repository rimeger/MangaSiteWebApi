using AutoMapper;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.TitleFeatures.Commands.Create
{
    public class CreateTitleMapper : Profile
    {
        public CreateTitleMapper()
        {
            CreateMap<CreateTitleCommand, MangaTitle>().ReverseMap();
        }
    }
}
