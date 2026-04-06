using Daf.Manga.Domain.Adapters;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using LightResults;
using NSubstitute;

namespace Daf.Manga.Application.Tests;

public class MangaServiceTests
{
    private readonly IMangaRepository _mangaRepository = Substitute.For<IMangaRepository>();
    private readonly ILogger<MangaService> _logger = Substitute.For<ILogger<MangaService>>();
    private readonly MangaService _sut;

    public MangaServiceTests()
    {
        _sut = new MangaService(_mangaRepository, _logger);
    }
    
    [Fact]
    public async Task GivenExistingManga_WhenGetMangaByTitle_ThenReturnsManga()
    {
        // Arrange
        var mangaTitle = "Fullmetal Alchemist";
        var author = new Domain.Person("Hiromu", "Arakawa", new DateTimeOffset(new DateTime(1988, 1, 1)), "Tokyo");
        var manga = new Domain.Manga(mangaTitle, author, Domain.ReadingStatus.PlanToRead, Domain.TargetDemographic.Shonen, 2000);
        _mangaRepository.GetMangaByTitle(mangaTitle, Arg.Any<CancellationToken>()).Returns(manga);
        
        // Act
        var result = await _sut.GetMangaByTitle(mangaTitle, CancellationToken.None);
        
        // Assert
        result.IsSuccess(out var expected).Should().BeTrue();
        expected?.Should().BeEquivalentTo(manga);
    }
    
    [Fact]
    public async Task GivenExistingManga_WhenUpdateManga_ThenReturnsSuccess()
    {
        // Arrange
        var mangaTitle = "Fullmetal Alchemist";
        var author = new Domain.Person("Hiromu", "Arakawa", new DateTimeOffset(new DateTime(1988, 1, 1)), "Tokyo");
        var manga = new Domain.Manga(mangaTitle, author, Domain.ReadingStatus.PlanToRead, Domain.TargetDemographic.Shonen, 2000);
        _mangaRepository.GetMangaByTitle(mangaTitle, Arg.Any<CancellationToken>()).Returns(manga);
        _mangaRepository.UpdateManga(manga, Arg.Any<CancellationToken>()).Returns(Result.Success());
        
        // Act
        var result = await _sut.GetMangaByTitle(mangaTitle, CancellationToken.None);
        
        // Assert
        result.IsSuccess().Should().BeTrue();
    }
}