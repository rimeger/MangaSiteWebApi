using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.UserFeatures.Queries.GetBookmarks
{
    public record GetBookmarksRequest(string username) : IRequest<List<MangaTitleDto>> { }
    public class GetBookmarksHandler : IRequestHandler<GetBookmarksRequest, List<MangaTitleDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetBookmarksHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<List<MangaTitleDto>> Handle(GetBookmarksRequest request, CancellationToken cancellationToken)
        {
            User current = await _userService.GetByUserName(request.username);
            var titles = await _userService.GetBookmarksAsync(current.Id);
            return _mapper.Map<List<MangaTitleDto>>(titles);
        }
    }
}
