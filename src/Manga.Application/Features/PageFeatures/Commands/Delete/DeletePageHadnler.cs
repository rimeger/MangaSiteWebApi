using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Commands.Delete
{
    public record DeletePageCommand(Guid id) : IRequest { }
    public class DeletePageHadnler : IRequestHandler<DeletePageCommand>
    {
        private readonly IMangaPageService _pageService;

        public DeletePageHadnler(IMangaPageService pageService)
        {
            _pageService = pageService;
        }
        public async Task Handle(DeletePageCommand request, CancellationToken cancellationToken)
        {
            var page = await _pageService.GetByIdAsync(request.id);
            if(page is null)
            {
                throw new NotFoundException($"There is no page with id {request.id}");
            }
            _pageService.Remove(page);
        }
    }
}
