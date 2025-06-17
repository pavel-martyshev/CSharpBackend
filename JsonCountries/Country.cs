namespace JsonCountries;

public class Country(string name, List<Dictionary<string, string>> currencies, int population)
{
    public string Name { get; set; } = name;

    public List<Dictionary<string, string>> Currencies { get; set; } = currencies;

    public int Population { get; set; } = population;
}