using AutoMapper;
using FluentValidation;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manga.MediatR.MangaTitle.Commands.Create
{
    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, MangaTitleDto>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTitleCommand> _validator;

        public CreateTitleCommandHandler(IMangaTitleService titleService, IMapper mapper, IValidator<CreateTitleCommand> validator)
        {
            _titleService = titleService;
            _mapper = mapper;
            _validator = validator;
        }
        async Task<MangaTitleDto> IRequestHandler<CreateTitleCommand, MangaTitleDto>.Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);
            
            var mangaTitle = _mapper.Map<Models.MangaTitle>(request);
            mangaTitle.Id = Guid.NewGuid();
            mangaTitle.CreatedDate = DateTime.Now;
            mangaTitle.UpdatedDate = DateTime.Now;
            await _titleService.CreateAsync(mangaTitle);
            return _mapper.Map<MangaTitleDto>(mangaTitle);
        }
    }
}
