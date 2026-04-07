namespace Daf.Manga.Application.Dto;

public record Person(string FirstName, string LastName, DateTimeOffset BirthDate, string BirthPlace)
{
    public string FullName => $"{FirstName} {LastName}";
    public Domain.Person ToDomain() => new(FirstName, LastName, BirthDate, BirthPlace);
    public static Person FromDomain(Domain.Person person) => new(person.FirstName, person.LastName, person.BirthDate, person.BirthPlace);
}