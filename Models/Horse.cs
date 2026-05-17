namespace BPO_3.Models;

/// <summary>
/// Лошадь - конкретный наследник класса Animal.
/// В этой учебной иерархии она не относится к классу Artiodactyl,
/// потому что лошади являются непарнокопытными.
/// </summary>
public class Horse : Animal
{
    public string Color { get; }

    public Horse(string name, int age, double weight, string color)
        : base(name, age, weight)
    {
        Color = color;
    }

    public override void Talk()
    {
        Console.WriteLine($"{Name}: И-го-го!");
    }

    public override void PrintProperties()
    {
        base.PrintProperties();
        Console.WriteLine($"Масть: {Color}");
    }

    ~Horse()
    {
        // Деструктор класса Horse.
    }
}
