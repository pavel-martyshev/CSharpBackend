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

            var allCurrencies = countries.SelectMany(c => c.Currencies).ToList();

            Console.WriteLine("Перечень всех валют:");
            Console.WriteLine(string.Join(Environment.NewLine, allCurrencies));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Ошибка при чтении JSON: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }
}