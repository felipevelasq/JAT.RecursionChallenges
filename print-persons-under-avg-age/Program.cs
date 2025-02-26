record Person(string Name, int Age, List<Person> Children)
{
    public Person(string Name, int Age) : this(Name, Age, []) { }
}

class Program{
    static void Main()
    {
        var persons = new List<Person>
        {
            new("Alice", 30),
            new("Bob", 80,
            [
                new("Eve", 60,
                [
                    new("Loid", 40,
                    [
                        new("Shan", 20)
                    ]),
                    new("Kevin", 40)
                ]),
                new("Mallory", 3)
            ]),
            new("Charlie", 35),
            new("Diana", 28)
        };

        try
        {
            var averageAge = GetAverageAgeValue(persons);
            var averageAgeRounded = (int)Math.Round(averageAge, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Average Age: {averageAge:F1} | {averageAgeRounded}");

            PrintPersonsUnderAverageAge(persons, averageAgeRounded);
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintPersonsUnderAverageAge(List<Person> persons, int averageAgeRounded)
    {
        if (persons == null || persons.Count == 0)
        {
            throw new ArgumentException("No persons provided");
        }

        PrintPersonsUnderAverageAgeRecursively(persons, averageAgeRounded);
    }

    private static void PrintPersonsUnderAverageAgeRecursively(List<Person> persons, int averageAgeRounded, int index = 1)
    {
        var currentPerson = persons[index-1];
        if (currentPerson.Age <= averageAgeRounded)
        {
            Console.WriteLine($"Name: {currentPerson.Name}, Age: {currentPerson.Age}");
        }

        if (currentPerson.Children.Count > 0)
        {
            PrintPersonsUnderAverageAgeRecursively(currentPerson.Children, averageAgeRounded);
        }

        if (index < persons.Count)
        {
            PrintPersonsUnderAverageAgeRecursively(persons, averageAgeRounded, index+1);
        }
    }

    private static decimal GetAverageAgeValue(List<Person> persons)
    {
        if (persons == null || persons.Count == 0)
        {
            throw new DivideByZeroException("No persons provided");
        }

        var personsCount = CountPersons(persons);

        return CalculateAverageAgeValueRecursively(persons, personsCount);
    }

    private static int CountPersons(List<Person> persons)
    {
        return CountPersonsRecursively(persons);
    }

    private static int CountPersonsRecursively(List<Person> persons, int index = 1)
    {
        var currentPerson = persons[index-1];
        var result = 1;

        if (currentPerson.Children.Count > 0)
        {
            result += CountPersonsRecursively(currentPerson.Children);
        }

        if (index < persons.Count)
        {
            return result + CountPersonsRecursively(persons, index+1);
        }

        return result;
    }

    private static decimal CalculateAverageAgeValueRecursively(List<Person> persons, int personsCount, int index = 1)
    {
        var currentPerson = persons[index-1];
        
        decimal currentPersonAverageAgeValue = persons[index-1].Age/(decimal)personsCount;

        decimal result = currentPersonAverageAgeValue;
        if (currentPerson.Children.Count > 0)
        {
            result += CalculateAverageAgeValueRecursively(currentPerson.Children, personsCount);
        }

        if (index < persons.Count)
        {
            return result + CalculateAverageAgeValueRecursively(persons, personsCount, index+1);
        }

        return result;
    }
}