using FluentAssertions;
using Manga.Application.Repositories;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.Application.UnitTests.ServicesTests
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepositoryMock;
        public UserServiceTests()
        {
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _userService = new UserService(_userRepositoryMock);
        }

        [Fact]
        public async void GetBookmarksAsync_Should_ReturnAllBookmarkedTitles()
        {
            //Arrange
            var expectedList = new List<MangaTitle> {
                new MangaTitle
                    {
                        TitleName = "Test",
                        Author = "NoName",
                        Description = "Loren ipsum",
                        PosterUrl = "https://example.com"
                    }
            };
            var user = new User();
            var result = new List<MangaTitle>();
            _userRepositoryMock.GetBookmarksAsync(user.Id).Returns(expectedList);

            //Act
            result = await _userService.GetBookmarksAsync(user.Id);

            //Assert
            await _userRepositoryMock.Received(1).GetBookmarksAsync(user.Id);
            result.Should().BeOfType<List<MangaTitle>>();
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public async void CreateAsync_Should_CallCreateOnce()
        {
            //Arrange
            var user = new User
            {
                UserName = "Test",
                Email = "test@test.com",
            };

            //Act
            await _userService.CreateAsync(user);

            //Assert
            await _userRepositoryMock.Received(1).CreateAsync(user);
        }
        [Fact]
        public async void GetLikedChaptersAsync_Should_ReturnAllLikedChapters()
        {
            //Arrange
            var expectedList = new List<MangaChapter> {
                new MangaChapter
                    {
                        ChapterName = "Test",
                        ChapterNumber = 1
                    }
            };
            var user = new User();
            var result = new List<MangaChapter>();
            _userRepositoryMock.GetLikedChaptersAsync(user.Id).Returns(expectedList);

            //Act
            result = await _userService.GetLikedChaptersAsync(user.Id);

            //Assert
            await _userRepositoryMock.Received(1).GetLikedChaptersAsync(user.Id);
            result.Should().BeOfType<List<MangaChapter>>();
            result.Should().BeEquivalentTo(expectedList);
        }
        [Fact]
        public async void GetByUserName_Should_ReturnUser()
        {
            //Arrange
            var user = new User
            {
                UserName = "Test",
                Email = "test@test.com",
            };
            string username = "Test";
            var result = new User();
            _userRepositoryMock.GetByUserName(username).Returns(user);

            //Act
            result = await _userService.GetByUserName(username);

            //Assert
            await _userRepositoryMock.Received(1).GetByUserName(username);
            result.Should().BeOfType<User>();
            result.Should().BeEquivalentTo(user);
        }
    }
}
