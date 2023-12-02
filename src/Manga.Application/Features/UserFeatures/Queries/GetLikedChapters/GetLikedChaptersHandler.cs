using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.UserFeatures.Queries.GetLikedChapters
{
    public record GetLikedChaptersRequest(string username) : IRequest<List<MangaChapterDto>> { }
    public class GetLikedChaptersHandler : IRequestHandler<GetLikedChaptersRequest, List<MangaChapterDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetLikedChaptersHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<List<MangaChapterDto>> Handle(GetLikedChaptersRequest request, CancellationToken cancellationToken)
        {
            User current = await _userService.GetByUserName(request.username);
            var chapters = await _userService.GetLikedChaptersAsync(current.Id);
            return _mapper.Map<List<MangaChapterDto>>(chapters);
        }
    }
}
