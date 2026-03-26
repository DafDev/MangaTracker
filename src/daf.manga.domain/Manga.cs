namespace daf.manga.domain;

public class Manga(string title, Person author, ReadingStatus status, TargetDemographic targetDemographic, int year, string? description = null) 
{
    public string Title { get;  set;} = title;
    public Person Author { get; set; } = author;
    public ReadingStatus Status { get; set; } = status;
    public TargetDemographic TargetDemographic { get; set;} = targetDemographic;
    public int Year { get; set; } = year;
    public string? Description { get; set; } = description;

}
