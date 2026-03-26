namespace daf.manga.domain;

public record Person(string FirstName, string LastName, DateTimeOffset BirthDate, string BirthPlace)
{
    public string FullName => $"{FirstName} {LastName}";
}