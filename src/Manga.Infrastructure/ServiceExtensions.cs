﻿using Manga.Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Manga.Application.Repositories;
using Manga.Infrastructure.Repositories;

namespace Manga.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("Manga.WebAPI"));
            });
            services.AddScoped<IMangaChapterRepository, MangaChapterRepository>();
            services.AddScoped<IMangaPageRepository, MangaPageRepository>();
            services.AddScoped<IMangaTitleRepository, MangaTitleRepository>();
        }
    }
}
