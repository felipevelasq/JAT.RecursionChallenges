record Person(string Name, int Age);

class Program
{
    static void Main()
    {
        var persons = new List<Person>
        {
            new("Alice", 30),
            new("Bob", 25),
            new("Charlie", 35),
            new("Diana", 28)
        };

        try
        {
            var averageAge = GetAverageAge([.. persons.Select(p => p.Age)]);
            var roundedAvgAge = (int)Math.Round(averageAge, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Average Age: {averageAge} | {roundedAvgAge}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static decimal GetAverageAge(List<int> ages)
    {
        if (ages == null || ages.Count == 0)
        {
            throw new DivideByZeroException("No ages provided");
        }

        return CalculateAverageValueRecursively(ages);
    }

    private static decimal CalculateAverageValueRecursively(List<int> values, int index = 1)
    {
        decimal averageValue = values[index-1]/(decimal)values.Count;

        if (index == values.Count)
        {
            return averageValue;
        }
        else
        {
            return averageValue + CalculateAverageValueRecursively(values, index+1);
        }
    }
}