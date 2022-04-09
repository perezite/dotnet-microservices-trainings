// See https://aka.ms/new-console-template for more information

while(true)
{
    Console.WriteLine("Update");
    Thread.Sleep(500);
    using var httpClient = new HttpClient();
    var api1Response = await httpClient.GetAsync("http://localhost:5090/weatherforecast");
    var api2Response = await httpClient.GetAsync("http://localhost:5172/weatherforecast");

    var message1 = await api1Response.Content.ReadAsStringAsync();
    var message2 = await api2Response.Content.ReadAsStringAsync();

    Console.WriteLine(message1.Substring(0, 100) + "...");
    Console.WriteLine(message1.Substring(0, 200) + "...");

}
