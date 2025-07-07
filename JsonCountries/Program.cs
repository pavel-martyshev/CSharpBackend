using Newtonsoft.Json;

namespace JsonCountries;

internal class Program
{
    private static readonly string CountriesJsonPath = Path.Combine("..", "..", "..", "countries.json");

    public static void Main(string[] args)
    {
        try
        {
            var countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(CountriesJsonPath));

            ArgumentNullException.ThrowIfNull(countries);

            var populationSum = countries.Sum(c => c.Population);

            Console.WriteLine($"Суммарная численность по всем странам = {populationSum}");

            Console.WriteLine();

            var allCurrencies = countries
                .SelectMany(c => c.Currencies)
                .DistinctBy(c => c.Symbol)
                .ToList();

            Console.WriteLine("Перечень всех валют:");
            Console.WriteLine(string.Join(Environment.NewLine, allCurrencies));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Ошибка при чтении JSON: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {e.Message}");
        }
    }
}