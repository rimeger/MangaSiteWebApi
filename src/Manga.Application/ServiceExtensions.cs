using FluentValidation;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            ValidatorOptions.Global.LanguageManager.Enabled = false;

            services.AddScoped<IMangaTitleService, MangaTitleService>();
            services.AddScoped<IMangaChapterService, MangaChapterService>();
            services.AddScoped<IMangaPageService, MangaPageService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
