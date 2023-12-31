﻿using AutoMapper;
using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Commands.Create
{
    public record CreatePageCommand : IRequest<MangaPageDto>
    {
        public string ImageUrl { get; set; } = String.Empty;
        public Guid ChapterId { get; set; }
    }
    public class CreatePageHandler : IRequestHandler<CreatePageCommand, MangaPageDto>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IMangaChapterService _chapterService;
        private readonly IValidator<CreatePageCommand> _validator;

        public CreatePageHandler(IMangaPageService pageService, IMapper mapper,
            IMangaChapterService chapterService, IValidator<CreatePageCommand> validator)
        {
            _pageService = pageService;
            _mapper = mapper;
            _chapterService = chapterService;
            _validator = validator;
        }
        public async Task<MangaPageDto> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var chapter = await _chapterService.GetByIdAsync(request.ChapterId);
            if(chapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.ChapterId}");
            }
            var pages = await _pageService.GetAllByChapterAsync(chapter);
            var page = _mapper.Map<MangaPage>(request);
            page.Id = Guid.NewGuid();
            page.PageNumber = pages.Count + 1;
            page.CreatedDate = DateTime.Now;
            page.UpdatedDate = DateTime.Now;
            page.MangaChapter = chapter;
            await _pageService.CreateAsync(page);
            return _mapper.Map<MangaPageDto>(page);
        }
    }
}
