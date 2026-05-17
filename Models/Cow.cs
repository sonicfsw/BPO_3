namespace BPO_3.Models;

/// <summary>
/// Корова является парнокопытным животным.
/// </summary>
public class Cow : Artiodactyl
{
    public string Color { get; }

    public Cow(string name, int age, double weight, string color, bool hasHorns)
        : base(name, age, weight, hasHorns)
    {
        Color = color;
    }

    public override void Talk()
    {
        Console.WriteLine($"{Name}: Му-у!");
    }

    public override void PrintProperties()
    {
        base.PrintProperties();
        Console.WriteLine($"Окрас: {Color}");
    }

    ~Cow()
    {
        // Деструктор класса Cow.
    }
}
