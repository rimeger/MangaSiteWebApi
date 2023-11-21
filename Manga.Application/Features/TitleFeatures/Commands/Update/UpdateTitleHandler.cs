using AutoMapper;
using FluentValidation;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.TitleFeatures.Commands.Update
{
    public record UpdateTitleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
    }
    public class UpdateTitleHandler : IRequestHandler<UpdateTitleCommand>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTitleCommand> _validator;

        public UpdateTitleHandler(IMangaTitleService titleService, IMapper mapper, IValidator<UpdateTitleCommand> validator)
        {
            _titleService = titleService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var originalTitle = await _titleService.GetByIdAsync(request.Id);
            if (originalTitle is null)
            {
                throw new NotFoundException($"There is no title with id {request.Id}");
            }

            await _titleService.Untrack(originalTitle);
            var updatedTitle = _mapper.Map<MangaTitle>(request);
            updatedTitle.CreatedDate = originalTitle.CreatedDate;
            updatedTitle.UpdatedDate = DateTime.Now;
            await _titleService.UpdateAsync(updatedTitle);
        }
    }
}
