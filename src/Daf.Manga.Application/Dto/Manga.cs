namespace Daf.Manga.Application.Dto;

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
    
    public Domain.Manga ToDomain() => new(
        Title,
        Author.ToDomain(),
        Enum.Parse<Domain.ReadingStatus>(Status.ToString()),
        Enum.Parse<Domain.TargetDemographic>(TargetDemographic.ToString()),
        Year,
        Description,
        VolumeCount,
        ChapterCount,
        Id);

    public static Manga FromDomain(Domain.Manga manga) => new(
        manga.Title,
        Person.FromDomain(manga.Author),
        Enum.Parse<ReadingStatus>(manga.Status.ToString()),
        Enum.Parse<TargetDemographic>(manga.TargetDemographic.ToString()),
        manga.Year,
        manga.Description,
        manga.VolumeCount,
        manga.ChapterCount,
        manga.Id
    );

}