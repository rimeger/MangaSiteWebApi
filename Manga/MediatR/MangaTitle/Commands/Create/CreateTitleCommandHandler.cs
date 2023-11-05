using AutoMapper;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Create
{
    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public CreateTitleCommandHandler(IMangaTitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            _mapper = mapper;
        }
        public async Task Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            var mangaTitle = _mapper.Map<Models.MangaTitle>(request);
            mangaTitle.Id = Guid.NewGuid();
            mangaTitle.CreatedDate = DateTime.Now;
            mangaTitle.UpdatedDate = DateTime.Now;
            await _titleService.CreateAsync(mangaTitle);
        }
    }
}
