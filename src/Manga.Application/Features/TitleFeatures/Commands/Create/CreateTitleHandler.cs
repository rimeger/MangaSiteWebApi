using AutoMapper;
using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.TitleFeatures.Commands.Create
{
    public record CreateTitleCommand : IRequest<MangaTitleDto>
    {
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
    }
    public class CreateTitleHandler : IRequestHandler<CreateTitleCommand, MangaTitleDto>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTitleCommand> _validator;

        public CreateTitleHandler(IMangaTitleService titleService, IMapper mapper, IValidator<CreateTitleCommand> validator)
        {
            _titleService = titleService;
            _mapper = mapper;
            _validator = validator;
        }
        async Task<MangaTitleDto> IRequestHandler<CreateTitleCommand, MangaTitleDto>.Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            
            var mangaTitle = _mapper.Map<MangaTitle>(request);
            mangaTitle.Id = Guid.NewGuid();
            mangaTitle.CreatedDate = DateTime.Now;
            mangaTitle.UpdatedDate = DateTime.Now;
            await _titleService.CreateAsync(mangaTitle);
            return _mapper.Map<MangaTitleDto>(mangaTitle);
        }
    }
}
