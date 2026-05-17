namespace BPO_3.Models;

/// <summary>
/// Собака - конкретный наследник класса Animal.
/// </summary>
public class Dog : Animal
{
    public string Breed { get; }

    public Dog(string name, int age, double weight, string breed)
        : base(name, age, weight)
    {
        Breed = breed;
    }

    public override void Talk()
    {
        Console.WriteLine($"{Name}: Гав-гав!");
    }

    public override void PrintProperties()
    {
        base.PrintProperties();
        Console.WriteLine($"Порода: {Breed}");
    }

    ~Dog()
    {
        // Деструктор класса Dog.
    }
}
