using AutoMapper;
using FluentValidation;
using Manga.Exceptions;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Update
{
    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTitleCommand> _validator;

        public UpdateTitleCommandHandler(IMangaTitleService titleService, IMapper mapper, IValidator<UpdateTitleCommand> validator)
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
            var updatedTitle = _mapper.Map<Models.MangaTitle>(request);
            updatedTitle.CreatedDate = originalTitle.CreatedDate;
            updatedTitle.UpdatedDate = DateTime.Now;
            await _titleService.UpdateAsync(updatedTitle);
        }
    }
}
