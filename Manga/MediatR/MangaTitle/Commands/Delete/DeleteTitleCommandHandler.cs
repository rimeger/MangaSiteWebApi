using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Delete
{
    public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand>
    {
        private readonly IMangaTitleService _titleService;

        public DeleteTitleCommandHandler(IMangaTitleService titleService)
        {
            _titleService = titleService;
        }
        public async Task Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
        {
            var title = await _titleService.GetByIdAsync(request.id);
            await _titleService.RemoveAsync(title);
        }
    }
}
