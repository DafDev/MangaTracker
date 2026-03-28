namespace Daf.Manga.Domain;

public record Person(string FirstName, string LastName, DateTimeOffset BirthDate, string BirthPlace)
{
    public string FullName => $"{FirstName} {LastName}";
}