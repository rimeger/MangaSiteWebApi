using AutoMapper;
using Manga.Services.IServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Manga.MediatR.MangaTitle.Commands.Update
{
    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public UpdateTitleCommandHandler(IMangaTitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            _mapper = mapper;
        }
        public async Task Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            var originalTitle = await _titleService.GetByIdAsync(request.Id);
            await _titleService.Untrack(originalTitle);
            var updatedTitle = _mapper.Map<Models.MangaTitle>(request);
            updatedTitle.CreatedDate = originalTitle.CreatedDate;
            updatedTitle.UpdatedDate = DateTime.Now;
            await _titleService.UpdateAsync(updatedTitle);
        }
    }
}
