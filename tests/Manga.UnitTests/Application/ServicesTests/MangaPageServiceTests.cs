using FluentAssertions;
using Manga.Application.Repositories;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.UnitTests.Application.ServicesTests
{
    public class MangaPageServiceTests
    {
        private readonly IMangaPageRepository _pageRepositoryMock;
        private readonly IMangaPageService _pageService;
        public MangaPageServiceTests()
        {
            _pageRepositoryMock = Substitute.For<IMangaPageRepository>();
            _pageService = new MangaPageService(_pageRepositoryMock);
        }

        [Fact]
        public async void GetAllAsync_Should_ReturnAllPage()
        {
            //Arrange
            var expectedList = new List<MangaPage> {
                new MangaPage
                    {
                        PageNumber = 1,
                        ImageUrl = "https://example.com"
                    }
            };
            var result = new List<MangaPage>();
            _pageRepositoryMock.GetAllAsync().Returns(expectedList);

            //Act
            result = await _pageService.GetAllAsync();

            //Assert
            await _pageRepositoryMock.Received(1).GetAllAsync();
            result.Should().BeOfType<List<MangaPage>>();
            result.Should().BeEquivalentTo(expectedList);
        }
        [Fact]
        public async void GetByIdAsync_Should_ReturnPage()
        {
            //Arrange
            var id = Guid.NewGuid();
            var expectedPage = new MangaPage
            {
                PageNumber = 1,
                ImageUrl = "https://example.com"
            };
            var result = new MangaPage();
            _pageRepositoryMock.GetByIdAsync(id).Returns(expectedPage);

            //Act
            result = await _pageService.GetByIdAsync(id);

            //Assert
            await _pageRepositoryMock.Received(1).GetByIdAsync(id);
            result.Should().BeOfType<MangaPage>();
            result.Should().BeEquivalentTo(expectedPage);
        }
        [Fact]
        public async void RemoveAsync_Should_CallRemoveOnce()
        {
            //Arrange
            var page = new MangaPage
            {
                PageNumber = 1,
                ImageUrl = "https://example.com"
            };

            //Act
            await _pageService.RemoveAsync(page);

            //Assert
            await _pageRepositoryMock.Received(1).RemoveAsync(page);
        }
        [Fact]
        public async void Untrack_Should_CallUntrackOnce()
        {
            //Arrange
            var page = new MangaPage
            {
                PageNumber = 1,
                ImageUrl = "https://example.com"
            };

            //Act
            await _pageService.Untrack(page);

            //Assert
            await _pageRepositoryMock.Received(1).Untrack(page);
        }
        [Fact]
        public async void UpdateAsync_Should_CallUpdateOnce()
        {
            //Arrange
            var page = new MangaPage
            {
                PageNumber = 1,
                ImageUrl = "https://example.com"
            };

            //Act
            await _pageService.UpdateAsync(page);

            //Assert
            await _pageRepositoryMock.Received(1).UpdateAsync(page);
        }
        [Fact]
        public async void CreateAsync_Should_CallCreateOnce()
        {
            //Arrange
            var page = new MangaPage
            {
                PageNumber = 1,
                ImageUrl = "https://example.com"
            };

            //Act
            await _pageService.CreateAsync(page);

            //Assert
            await _pageRepositoryMock.Received(1).CreateAsync(page);
        }
        [Fact]
        public async void GetAllByChapterAsync_Should_ReturnChapters()
        {
            //Arrange
            var chapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };
            var expectedList = new List<MangaPage> {
                new MangaPage
                    {
                        PageNumber = 1,
                        ImageUrl = "https://example.com"
                    }
            };
            var result = new List<MangaPage>();
            _pageRepositoryMock.GetAllByChapterAsync(chapter).Returns(expectedList);

            //Act
            result = await _pageService.GetAllByChapterAsync(chapter);

            //Assert
            await _pageRepositoryMock.Received(1).GetAllByChapterAsync(chapter);
            result.Should().BeOfType<List<MangaPage>>();
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}
