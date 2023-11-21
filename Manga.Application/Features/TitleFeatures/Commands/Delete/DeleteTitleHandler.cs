using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.TitleFeatures.Commands.Delete
{
    public record DeleteTitleCommand(Guid id) : IRequest { }
    public class DeleteTitleHandler : IRequestHandler<DeleteTitleCommand>
    {
        private readonly IMangaTitleService _titleService;

        public DeleteTitleHandler(IMangaTitleService titleService)
        {
            _titleService = titleService;
        }
        public async Task Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
        {
            var title = await _titleService.GetByIdAsync(request.id);
            if (title is null)
            {
                throw new NotFoundException($"There is no title with id {request.id}"); 
            }
            await _titleService.RemoveAsync(title);
        }
    }
}
