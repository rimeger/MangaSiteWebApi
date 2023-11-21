using AutoMapper;
using FluentValidation;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Commands.Update
{
    public record UpdatePageCommand : IRequest
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string ImageUrl { get; set; }
    }
    public class UpdatePageHandler : IRequestHandler<UpdatePageCommand>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdatePageCommand> _validator;

        public UpdatePageHandler(IMangaPageService pageService, IMapper mapper, IValidator<UpdatePageCommand> validator)
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
            var updatedPage = _mapper.Map<MangaPage>(request);
            updatedPage.UpdatedDate = DateTime.Now;
            updatedPage.CreatedDate = originalPage.CreatedDate;
            await _pageService.UpdateAsync(updatedPage);
        }
    }
}
