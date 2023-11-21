using AutoMapper;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.PageFeatures.Commands.Create
{
    public class CreatePageMapper : Profile
    {
        public CreatePageMapper()
        {
            CreateMap<CreatePageCommand, MangaPage>().ReverseMap();
        }
    }
}
