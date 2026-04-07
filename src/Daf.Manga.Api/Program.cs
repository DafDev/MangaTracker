using Daf.Manga.Application;
using Daf.Manga.Infra;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddMangaInfrastructure(builder.Configuration);
builder.Services.AddMangaApplication();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.Run();