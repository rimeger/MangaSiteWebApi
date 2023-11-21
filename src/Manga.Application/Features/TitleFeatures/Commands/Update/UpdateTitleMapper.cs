using AutoMapper;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.TitleFeatures.Commands.Update
{
    public class UpdateTitleMapper : Profile
    {
        public UpdateTitleMapper()
        {
            CreateMap<UpdateTitleCommand, MangaTitle>().ReverseMap();
        }
    }
}
