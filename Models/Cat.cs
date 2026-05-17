namespace BPO_3.Models;

/// <summary>
/// Кошка - конкретный наследник класса Animal.
/// </summary>
public class Cat : Animal
{
    public string Color { get; }

    public Cat(string name, int age, double weight, string color)
        : base(name, age, weight)
    {
        Color = color;
    }

    public override void Talk()
    {
        Console.WriteLine($"{Name}: Мяу!");
    }

    public override void PrintProperties()
    {
        base.PrintProperties();
        Console.WriteLine($"Окрас: {Color}");
    }

    ~Cat()
    {
        // Деструктор класса Cat.
    }
}
