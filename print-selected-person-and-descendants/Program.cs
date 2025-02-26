record Person(string Name, int Age, List<Person> Children)
{
    public Person(string Name, int Age) : this(Name, Age, []) { }
}

class Program
{
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
            var selectedPerson = persons[1].Children[0].Children[0];
            var personFound = FindSpecificPerson(persons, selectedPerson);

            if (personFound is null)
            {
                Console.WriteLine($"Person ({selectedPerson.Name}, Age: {selectedPerson.Age}) not found.");
            }
            else
            {
                PrintPerson(personFound);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintPerson(Person person)
    {
        PrintPersonsRecursively(person);
    }

    private static void PrintPersonsRecursively(Person person, int level = 1)
    {
        for (int i = 0; i < level; i++)
        {
            Console.Write("-");
        }
        
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        if (person.Children.Count > 0)
        {
            foreach (var child in person.Children)
            {
                PrintPersonsRecursively(child, level + 1);
            }
        }
    }

    private static Person? FindSpecificPerson(List<Person> persons, Person person)
    {
        return FindSpecificPersonRecursively(persons, person);
    }

    private static Person? FindSpecificPersonRecursively(List<Person> persons, Person person, int index = 1)
    {
        var currentPerson = persons[index - 1];

        if (currentPerson == person)
        {
            return currentPerson;
        }

        if (currentPerson.Children.Count > 0)
        {
            var personFound = FindSpecificPersonRecursively(currentPerson.Children, person);
            if (personFound != null)
            {
                return personFound;
            }
        }

        if (index < persons.Count)
        {
            return FindSpecificPersonRecursively(persons, person, index + 1);
        }
        
        return null;
    }
}