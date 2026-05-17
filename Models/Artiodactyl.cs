namespace BPO_3.Models;

/// <summary>
/// Парнокопытное - промежуточный абстрактный класс.
/// Он нужен для животных с общими признаками парнокопытных,
/// но сам по себе не описывает конкретное животное.
/// </summary>
public abstract class Artiodactyl : Animal
{
    public bool HasHorns { get; }

    protected Artiodactyl(string name, int age, double weight, bool hasHorns)
        : base(name, age, weight)
    {
        HasHorns = hasHorns;
    }

    public override void PrintProperties()
    {
        base.PrintProperties();
        Console.WriteLine($"Есть рога: {(HasHorns ? "да" : "нет")}");
    }

    ~Artiodactyl()
    {
        // Деструктор промежуточного абстрактного класса.
    }
}
