using AutoMapper;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Update
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;

        public UpdatePageCommandHandler(IMangaPageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
        }
        public async Task Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            var originalPage = await _pageService.GetByIdAsync(request.Id);
            await _pageService.Untrack(originalPage);
            var updatedPage = _mapper.Map<Models.MangaPage>(request);
            updatedPage.UpdatedDate = DateTime.Now;
            updatedPage.CreatedDate = originalPage.CreatedDate;
            await _pageService.UpdateAsync(updatedPage);
        }
    }
}
