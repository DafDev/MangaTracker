using Daf.Manga.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Daf.Manga.Infra.Dto;

[BsonIgnoreExtraElements]
public class Manga(string title, Person author, ReadingStatus status, TargetDemographic targetDemographic, int year, string? description = null, int? volumeCount = null, int? chapterCount = null, Guid? id = null) 
{
    public string Title { get;  set;} = title;
    public Person Author { get; set; } = author;
    public ReadingStatus Status { get; set; } = status;
    public TargetDemographic TargetDemographic { get; set;} = targetDemographic;
    public int Year { get; set; } = year;
    public string? Description { get; set; } = description;
    public int? VolumeCount { get; set; } = volumeCount;
    public int? ChapterCount { get; set; } = chapterCount;
    public ObjectId Id { get; set; } = id is null ? ObjectId.GenerateNewId() : ObjectId.Parse(id.ToString());
    public Domain.Manga ToDomain() => new(Title, Author, Status, TargetDemographic, Year, Description, VolumeCount, ChapterCount, Guid.Parse(Id.ToString()));
    public static Manga FromDomain(Domain.Manga manga) => new(manga.Title, manga.Author, manga.Status, manga.TargetDemographic, manga.Year, manga.Description, manga.VolumeCount, manga.ChapterCount, manga.Id);
}