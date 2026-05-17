namespace BPO_3.Models;

/// <summary>
/// Базовый класс для всех животных.
/// Класс абстрактный, потому что понятие "животное" слишком общее
/// и не задает конкретный звук для метода Talk.
/// </summary>
public abstract class Animal
{
    public string Name { get; }

    public int Age { get; }

    public double Weight { get; }

    protected Animal(string name, int age, double weight)
    {
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
