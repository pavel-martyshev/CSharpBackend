using Newtonsoft.Json;

namespace JsonCountries;

internal class Program
{
    private static readonly string CountriesJsonPath = Path.Combine("..", "..", "..", "countries.json");

    public static void Main(string[] args)
    {
        var countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(CountriesJsonPath));

        ArgumentNullException.ThrowIfNull(countries);

        Console.WriteLine($"Суммарная численность по всем странам - {countries.Sum(c => c.Population)}");

        Console.WriteLine();


        Console.WriteLine("Перечень всех валют:");
        Console.WriteLine(string.Join(
                Environment.NewLine,
                countries
                    .SelectMany(c => c.Currencies)
                    .Where(d => d.GetValueOrDefault("code") is not null && d.GetValueOrDefault("name") is not null)
                    .Select(d => $"  - {d["name"]} ({d["code"]})")
                    .Distinct()
                    .ToList()
            )
        );
    }
}