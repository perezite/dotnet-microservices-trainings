// See https://aka.ms/new-console-template for more information

// var api2Response = await httpClient.GetAsync("http://localhost:5172/weatherforecast");

using System.Text.Json;

static async Task Call(string url, string apiName, HttpClient httpClient)
{
    try
    {
        var api1Response = await httpClient.GetAsync(url);
        var message = await api1Response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var forecast = JsonSerializer.Deserialize<List<WeatherForecast>>(message, options);

        Console.WriteLine($"[{apiName}] Environment: " + forecast?[0].Summary);
    }
    catch (HttpRequestException)
    {
        Console.WriteLine($"[{apiName}] No Connection");
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine($"[{apiName}] Timeout");
    }
}

while (true)
{
    Console.WriteLine("Update");
    Thread.Sleep(500);

    var httpClient = new HttpClient();
    httpClient.Timeout = TimeSpan.FromSeconds(1);

    await Call("http://localhost:5090/weatherforecast", "Web Api 1", httpClient);
    await Call("http://localhost:5172/weatherforecast", "Web Api 2", httpClient);
}

internal record WeatherForecast(string? Summary);