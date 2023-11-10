using AutoMapper;
using FluentValidation;
using Manga.Exceptions;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Update
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdatePageCommand> _validator;

        public UpdatePageCommandHandler(IMangaPageService pageService, IMapper mapper, IValidator<UpdatePageCommand> validator)
        {
            _pageService = pageService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var originalPage = await _pageService.GetByIdAsync(request.Id);
            if(originalPage is null) 
            {
                throw new NotFoundException($"There is no page with id {request.Id}");
            }

            await _pageService.Untrack(originalPage);
            var updatedPage = _mapper.Map<Models.MangaPage>(request);
            updatedPage.UpdatedDate = DateTime.Now;
            updatedPage.CreatedDate = originalPage.CreatedDate;
            await _pageService.UpdateAsync(updatedPage);
        }
    }
}
