using Newtonsoft.Json;

namespace JsonCountries;

public class Country(string name, string capital, double currencies)
{
    [JsonProperty("country")]
    public string Name { get; set; } = name;

    public string Currency { get; set; } = capital;

    public double Population { get; set; } = currencies;
}