using AutoMapper;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Update
{
    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public UpdateChapterCommandHandler(IMangaChapterService chapterService, IMapper mapper)
        {
            _chapterService = chapterService;
            _mapper = mapper;
        }
        public async Task Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            var originalChapter = await _chapterService.GetByIdAsync(request.Id);
            await _chapterService.Untrack(originalChapter);
            var updatedChapter = _mapper.Map<Models.MangaChapter>(request);
            updatedChapter.UpdatedDate = DateTime.Now;
            updatedChapter.CreatedDate = originalChapter.CreatedDate;
            updatedChapter.MangaTitle = originalChapter.MangaTitle;
            await _chapterService.UpdateAsync(updatedChapter);
        }
    }
}
