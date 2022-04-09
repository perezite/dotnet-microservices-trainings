// See https://aka.ms/new-console-template for more information

using System.Text.Json;

while (true)
{
    Console.WriteLine("Update");
    Thread.Sleep(500);
    using var httpClient = new HttpClient();
    var api1Response = await httpClient.GetAsync("http://localhost:5090/weatherforecast");
    var api2Response = await httpClient.GetAsync("http://localhost:5172/weatherforecast");

    var message1 = await api1Response.Content.ReadAsStringAsync();
    var message2 = await api2Response.Content.ReadAsStringAsync();

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    var forecast1 = JsonSerializer.Deserialize<List<WeatherForecast>>(message1, options);
    var forecast2 = JsonSerializer.Deserialize<List<WeatherForecast>>(message2, options);

    Console.WriteLine("Environment: " + forecast1?[0].Summary);
    Console.WriteLine("Environment: " + forecast2?[0].Summary);
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
