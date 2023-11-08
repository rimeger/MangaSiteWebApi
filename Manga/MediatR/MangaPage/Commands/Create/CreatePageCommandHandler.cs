using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Create
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, MangaPageDto>
    {
        public CreatePageCommandHandler()
        {
            
        }
        public Task<MangaPageDto> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
