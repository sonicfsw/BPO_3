namespace BPO_3.Models;

/// <summary>
/// Базовый класс для всех животных.
/// Класс абстрактный, потому что понятие "животное" слишком общее
/// и не задает конкретный звук для метода Talk.
/// </summary>
public abstract class Animal
{
    public const int MaxAge = 100;

    public const double MaxWeight = 2000;

    public string Name { get; }

    public int Age { get; }

    public double Weight { get; }

    protected Animal(string name, int age, double weight)
    {
        if (age < 0 || age > MaxAge)
        {
            throw new ArgumentOutOfRangeException(nameof(age), $"Возраст должен быть от 0 до {MaxAge} лет.");
        }

        if (weight < 0 || weight > MaxWeight)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), $"Вес должен быть от 0 до {MaxWeight} кг.");
        }

        Name = name;
        Age = age;
        Weight = weight;
    }

    /// <summary>
    /// Каждое конкретное животное говорит по-своему,
    /// поэтому метод объявлен абстрактным.
    /// </summary>
    public abstract void Talk();

    /// <summary>
    /// Виртуальный метод вывода свойств можно расширять в наследниках.
    /// </summary>
    public virtual void PrintProperties()
    {
        Console.WriteLine($"Класс: {GetType().Name}");
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Вес: {Weight} кг");
    }

    ~Animal()
    {
        // Деструктор базового класса. Он будет вызван сборщиком мусора,
        // когда объект больше не используется программой.
    }
}
