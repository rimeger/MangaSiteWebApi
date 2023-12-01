using AutoMapper;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.UserFeatures.Commands.Register
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterCommand, User>().ReverseMap();
        }
    }
}
