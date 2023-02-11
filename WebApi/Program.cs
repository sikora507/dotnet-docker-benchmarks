using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var albums = new[]
{
    new Album("1", "Blue Train", "John Coltrane", 56.99),
    new Album("1", "Blue Train", "John Coltrane", 56.99),
    new Album("1", "Blue Train", "John Coltrane", 56.99),
};

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.AddContext<MySerializer>();
});

var app = builder.Build();
app.MapGet("/albums", () => albums);
app.Run();

public record Album(string ID, string Title, string Artist, double Price);


[JsonSerializable(typeof(Album[]))]
partial class MySerializer : JsonSerializerContext
{

}