HttpClient client = new HttpClient();
Console.WriteLine("Hello from dotnet 7 framework dependant.");
var response = await client.GetAsync("https://www.google.com/");
var bytes = await response.Content.ReadAsByteArrayAsync();
Console.WriteLine($"Got {bytes.Length} bytes.");
Console.ReadLine();