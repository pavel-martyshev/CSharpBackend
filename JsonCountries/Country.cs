namespace JsonCountries;

public class Country(string name, List<Currency> currencies, int population)
{
    public string Name { get; set; } = name;

    public List<Currency> Currencies { get; set; } = currencies;

    public int Population { get; set; } = population;
}