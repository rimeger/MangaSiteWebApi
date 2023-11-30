using Manga.Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Manga.Application.Repositories;
using Manga.Infrastructure.Repositories;
using Manga.Application.Abstractions;
using Manga.Infrastructure.Authentication;

namespace Manga.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DockerConnectionString"), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
            services.AddScoped<IMangaChapterRepository, MangaChapterRepository>();
            services.AddScoped<IMangaPageRepository, MangaPageRepository>();
            services.AddScoped<IMangaTitleRepository, MangaTitleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
