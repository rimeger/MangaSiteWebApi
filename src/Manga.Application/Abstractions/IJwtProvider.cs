using Manga.Domain.Entities;

namespace Manga.Application.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(User user); 
    }
}
