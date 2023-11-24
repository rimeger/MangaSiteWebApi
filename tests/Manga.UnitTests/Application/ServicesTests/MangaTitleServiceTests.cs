using FluentAssertions;
using Manga.Application.Repositories;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.UnitTests.Application.ServicesTests
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
        public async void RemoveAsync_Should_CallRemoveOnce()
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
            await _titleService.RemoveAsync(title);

            //Assert
            await _titleRepositoryMock.Received(1).RemoveAsync(title);
        }
        [Fact]
        public async void Untrack_Should_CallUntrackOnce()
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
            await _titleService.Untrack(title);

            //Assert
            await _titleRepositoryMock.Received(1).Untrack(title);
        }
        [Fact]
        public async void UpdateAsync_Should_CallUpdateOnce()
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
            await _titleService.UpdateAsync(title);

            //Assert
            await _titleRepositoryMock.Received(1).UpdateAsync(title);
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
    }
}
