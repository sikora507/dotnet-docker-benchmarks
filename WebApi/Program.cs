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

public struct Album
{
    public Album(string id, string title, string artist, double price)
    {
        ID = id;
        Title = title;
        Artist = artist;
        Price = price;
    }

    public string ID;
    public string Title;
    public string Artist;
    public double Price;
};


[JsonSerializable(typeof(Album[]))]
partial class MySerializer : JsonSerializerContext
{

}