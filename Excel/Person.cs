namespace Excel;

internal class Person(string name, string lastName, int age, string phoneNumber)
{
    public string Name { get; } = name;

    public string LastName { get; } = lastName;

    public int Age { get; } = age;

    public string PhoneNumber { get; } = phoneNumber;

    public override string ToString()
    {
        return $"""
                Name - {Name}
                Lastname - {LastName}
                Age - {Age}
                Phone number - {PhoneNumber}
                """;
    }
}