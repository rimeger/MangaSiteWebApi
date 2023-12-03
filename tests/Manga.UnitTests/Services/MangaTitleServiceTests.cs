using FluentAssertions;
using Manga.Application.Repositories;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.Application.UnitTests.ServicesTests
{
    public class MangaTitleServiceTests
    {
        private readonly IMangaTitleRepository _titleRepositoryMock;
        private readonly IMangaTitleService _titleService;
        public MangaTitleServiceTests()
        {
            _titleRepositoryMock = Substitute.For<IMangaTitleRepository>();
            _titleService = new MangaTitleService(_titleRepositoryMock);
        }

        [Fact]
        public async void GetAllAsync_Should_ReturnAllTitle()
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
            var result = new List<MangaTitle>();
            _titleRepositoryMock.GetAllAsync().Returns(expectedList);

            //Act
            result = await _titleService.GetAllAsync();

            //Assert
            await _titleRepositoryMock.Received(1).GetAllAsync();
            result.Should().BeOfType<List<MangaTitle>>();
            result.Should().BeEquivalentTo(expectedList);
        }
        [Fact]
        public async void GetByIdAsync_Should_ReturnTitle()
        {
            //Arrange
            var id = Guid.NewGuid();
            var expectedTitle = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };
            var result = new MangaTitle();
            _titleRepositoryMock.GetByIdAsync(id).Returns(expectedTitle);

            //Act
            result = await _titleService.GetByIdAsync(id);

            //Assert
            await _titleRepositoryMock.Received(1).GetByIdAsync(id);
            result.Should().BeOfType<MangaTitle>();
            result.Should().BeEquivalentTo(expectedTitle);
        }
        [Fact]
        public void RemoveAsync_Should_CallRemoveOnce()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };

            //Act
            _titleService.Remove(title);

            //Assert
            _titleRepositoryMock.Received(1).Remove(title);
        }
        [Fact]
        public void Untrack_Should_CallUntrackOnce()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };

            //Act
            _titleService.Untrack(title);

            //Assert
            _titleRepositoryMock.Received(1).Untrack(title);
        }
        [Fact]
        public void UpdateAsync_Should_CallUpdateOnce()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };

            //Act
            _titleService.Update(title);

            //Assert
            _titleRepositoryMock.Received(1).Update(title);
        }
        [Fact]
        public async void CreateAsync_Should_CallCreateOnce()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };

            //Act
            await _titleService.CreateAsync(title);

            //Assert
            await _titleRepositoryMock.Received(1).CreateAsync(title);
        }

        [Fact]
        public async void BookmarkTitle_Should_CallBookmarkOnce()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };
            var user = new User
            {
                UserName = "Test",
            };

            //Act
            await _titleService.BookmarkTitle(user, title);

            //Assert
            await _titleRepositoryMock.Received(1).BookmarkTitle(Arg.Is<UserTitle>(u => u.TitleId == title.Id && u.UserId == user.Id));
        }
    }
}
