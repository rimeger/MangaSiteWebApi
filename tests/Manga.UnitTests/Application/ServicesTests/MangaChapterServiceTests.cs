using FluentAssertions;
using Manga.Application.Repositories;
using Manga.Application.Services;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Manga.UnitTests.Application.ServicesTests
{
    public class MangaChapterServiceTests
    {
        private readonly IMangaChapterRepository _chapterRepositoryMock;
        private readonly IMangaChapterService _chapterService;
        public MangaChapterServiceTests()
        {
            _chapterRepositoryMock = Substitute.For<IMangaChapterRepository>();
            _chapterService = new MangaChapterService(_chapterRepositoryMock);
        }

        [Fact]
        public async void GetAllAsync_Should_ReturnAllChapter()
        {
            //Arrange
            var expectedList = new List<MangaChapter> { 
                new MangaChapter
                    {
                        ChapterName = "Test",
                        ChapterNumber = 1
                    } 
            };
            var result = new List<MangaChapter>();
            _chapterRepositoryMock.GetAllAsync().Returns(expectedList);

            //Act
            result = await _chapterService.GetAllAsync();

            //Assert
            await _chapterRepositoryMock.Received(1).GetAllAsync();
            result.Should().BeOfType<List<MangaChapter>>();
            result.Should().BeEquivalentTo(expectedList);
        }
        [Fact]
        public async void GetByIdAsync_Should_ReturnChapter()
        {
            //Arrange
            var id = Guid.NewGuid();
            var expectedChapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };
            var result = new MangaChapter();
            _chapterRepositoryMock.GetByIdAsync(id).Returns(expectedChapter);

            //Act
            result = await _chapterService.GetByIdAsync(id);

            //Assert
            await _chapterRepositoryMock.Received(1).GetByIdAsync(id);
            result.Should().BeOfType<MangaChapter>();
            result.Should().BeEquivalentTo(expectedChapter);
        }
        [Fact]
        public void RemoveAsync_Should_CallRemoveOnce()
        {
            //Arrange
            var chapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };

            //Act
            _chapterService.Remove(chapter);

            //Assert
            _chapterRepositoryMock.Received(1).Remove(chapter);
        }
        [Fact]
        public void Untrack_Should_CallUntrackOnce()
        {
            //Arrange
            var chapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };

            //Act
            _chapterService.Untrack(chapter);

            //Assert
            _chapterRepositoryMock.Received(1).Untrack(chapter);
        }
        [Fact]
        public void UpdateAsync_Should_CallUpdateOnce()
        {
            //Arrange
            var chapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };

            //Act
            _chapterService.Update(chapter);

            //Assert
            _chapterRepositoryMock.Received(1).Update(chapter);
        }
        [Fact]
        public async void CreateAsync_Should_CallCreateOnce()
        {
            //Arrange
            var chapter = new MangaChapter
            {
                ChapterName = "Test",
                ChapterNumber = 1
            };

            //Act
            await _chapterService.CreateAsync(chapter);

            //Assert
            await _chapterRepositoryMock.Received(1).CreateAsync(chapter);
        }
        [Fact]
        public async void GetAllByTitleAsync_Should_ReturnChapters()
        {
            //Arrange
            var title = new MangaTitle
            {
                TitleName = "Test",
                Author = "NoName",
                Description = "Loren ipsum",
                PosterUrl = "https://example.com"
            };
            var expectedList = new List<MangaChapter> {
                new MangaChapter
                    {
                        ChapterName = "Test",
                        ChapterNumber = 1
                    }
            };
            var result = new List<MangaChapter>();
            _chapterRepositoryMock.GetAllByTitleAsync(title).Returns(expectedList);

            //Act
            result = await _chapterService.GetAllByTitleAsync(title);

            //Assert
            await _chapterRepositoryMock.Received(1).GetAllByTitleAsync(title);
            result.Should().BeOfType<List<MangaChapter>>();
            result.Should().BeEquivalentTo(expectedList);
        }
    }
}
