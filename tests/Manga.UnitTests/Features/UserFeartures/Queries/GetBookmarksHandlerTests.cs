using AutoMapper;
using FluentAssertions;
using Manga.Application.Dto;
using Manga.Application.Features.UserFeatures.Queries.GetBookmarks;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.Application.UnitTests.Features.UserFeartures.Queries
{
    public class GetBookmarksHandlerTests
    {
        private readonly IUserService _userServiceMock;
        private readonly IMapper _mapper;
        public GetBookmarksHandlerTests()
        {
            _userServiceMock = Substitute.For<IUserService>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Handle_Should_ReturnAllBookmarkedTitles()
        {
            //Arrange
            var username = "username";
            var request = new GetBookmarksRequest(username);
            var handler = new GetBookmarksHandler(_userServiceMock, _mapper);
            var expectedList = new List<MangaTitleDto> {
                new MangaTitleDto
                    {
                        TitleName = "Test",
                        Author = "NoName",
                        Description = "Loren ipsum",
                        PosterUrl = "https://example.com"
                    }
            };
            var user = new User
            {
                UserName = username,
            };
            List<MangaTitle> list = new List<MangaTitle> {
                new MangaTitle
                    {
                        TitleName = "Test",
                        Author = "NoName",
                        Description = "Loren ipsum",
                        PosterUrl = "https://example.com"
                    }
            };
            _userServiceMock.GetByUserName(username).Returns(user);
            _userServiceMock.GetBookmarksAsync(user.Id).Returns(list);
            _mapper.Map<List<MangaTitleDto>>(Arg.Any<List<MangaTitle>>()).Returns(expectedList);

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            await _userServiceMock.Received(1).GetByUserName(username);
            await _userServiceMock.Received(1).GetBookmarksAsync(user.Id);

            result.Should().BeOfType<List<MangaTitleDto>>();
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}
