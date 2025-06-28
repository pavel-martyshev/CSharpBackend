namespace JsonCountries;

public class Currency(string code, string name, string symbol)
{
    public string Code { get; set; } = code;

    public string Name { get; set; } = name;

    public string Symbol { get; set; } = symbol;

    public override string ToString()
    {
        return $"{Name} ({Code}, {Symbol})";
    }
}