using AutoMapper;
using FluentAssertions;
using Manga.Application.Dto;
using Manga.Application.Features.UserFeatures.Queries.GetBookmarks;
using Manga.Application.Features.UserFeatures.Queries.GetLikedChapters;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Manga.Application.UnitTests.Features.UserFeartures.Queries
{
    public class GetLikedChaptersHandlerTests
    {
        private readonly IUserService _userServiceMock;
        private readonly IMapper _mapper;
        public GetLikedChaptersHandlerTests()
        {
            _userServiceMock = Substitute.For<IUserService>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Handle_Should_ReturnAllLikedChapters()
        {
            //Arrange
            var username = "username";
            var request = new GetLikedChaptersRequest(username);
            var handler = new GetLikedChaptersHandler(_userServiceMock, _mapper);
            var expectedList = new List<MangaChapterDto> {
                new MangaChapterDto
                    {
                        ChapterName = "Test",
                        ChapterNumber = 1
                    }
            };
            var user = new User
            {
                UserName = username,
            };
            var list = new List<MangaChapter> {
                new MangaChapter
                    {
                        ChapterName = "Test",
                        ChapterNumber = 1
                    }
            };
            _userServiceMock.GetByUserName(username).Returns(user);
            _userServiceMock.GetLikedChaptersAsync(user.Id).Returns(list);
            _mapper.Map<List<MangaChapterDto>>(Arg.Any<List<MangaChapter>>()).Returns(expectedList);

            //Act
            var result = await handler.Handle(request, default);

            //Assert
            await _userServiceMock.Received(1).GetByUserName(username);
            await _userServiceMock.Received(1).GetLikedChaptersAsync(user.Id);

            result.Should().BeOfType<List<MangaChapterDto>>();
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}
