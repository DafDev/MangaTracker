namespace Daf.Manga.Domain;

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
    public Guid Id { get; set; } = id ?? Guid.NewGuid();
}
