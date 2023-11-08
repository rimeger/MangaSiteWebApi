﻿using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Delete
{
    public class DeletePageCommandHadnler : IRequestHandler<DeletePageCommand>
    {
        private readonly IMangaPageService _pageService;

        public DeletePageCommandHadnler(IMangaPageService pageService)
        {
            _pageService = pageService;
        }
        public async Task Handle(DeletePageCommand request, CancellationToken cancellationToken)
        {
            var page = await _pageService.GetByIdAsync(request.id);
            await _pageService.RemoveAsync(page);
        }
    }
}
