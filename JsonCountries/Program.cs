using Newtonsoft.Json;

namespace JsonCountries;

internal class Program
{
    private static readonly string CountriesJsonPath = Path.Combine("..", "..", "..", "countries.json");

    public static void Main(string[] args)
    {
        var countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(CountriesJsonPath));

        ArgumentNullException.ThrowIfNull(countries);

        Console.WriteLine("Суммарная численность по всем странам:");
        Console.WriteLine(countries.Where(c => !double.IsNaN(c.Population)).Sum(c => c.Population));

        Console.WriteLine();

        Console.WriteLine("Перечень всех валют:");
        Console.WriteLine(string.Join(
            Environment.NewLine,
            countries.Where(c => c.Currency != "NaN").Select(c => c.Currency).Distinct().ToList()
            )
        );
    }
}
