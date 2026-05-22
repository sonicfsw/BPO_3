using System.Globalization;
using BPO_3.Models;

namespace BPO_3;

class Program
{
    static void Main()
    {
        try
        {
            Animal[] animals = ReadAnimals();
            PrintAnimals(animals);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Ошибка выполнения программы: {exception.Message}");
        }
    }

    private static Animal[] ReadAnimals()
    {
        int count = ReadInt("Введите количество животных: ", 1);
        Animal[] animals = new Animal[count];

        for (int i = 0; i < animals.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Животное {i + 1}:");
            animals[i] = ReadAnimal();
        }

        return animals;
    }

    private static Animal ReadAnimal()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Выберите тип животного:");
                Console.WriteLine("1 - корова");
                Console.WriteLine("2 - собака");
                Console.WriteLine("3 - лошадь");
                Console.WriteLine("4 - кошка");

                int type = ReadInt("Ваш выбор: ", 1, 4);
                string name = ReadRequiredString("Имя: ");
                int age = ReadInt("Возраст: ", 0, Animal.MaxAge);
                double weight = ReadDouble("Вес: ", 0, Animal.MaxWeight);

                return type switch
                {
                    1 => new Cow(name, age, weight, ReadRequiredString("Окрас: "), ReadBool("Есть рога? (да/нет): ")),
                    2 => new Dog(name, age, weight, ReadRequiredString("Порода: ")),
                    3 => new Horse(name, age, weight, ReadRequiredString("Масть: ")),
                    4 => new Cat(name, age, weight, ReadRequiredString("Окрас: ")),
                    _ => throw new ArgumentOutOfRangeException(nameof(type), "Неизвестный тип животного.")
                };
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"Ошибка ввода: {exception.Message}");
                Console.WriteLine("Повторите ввод животного заново.");
                Console.WriteLine();
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Ошибка формата: {exception.Message}");
                Console.WriteLine("Повторите ввод животного заново.");
                Console.WriteLine();
            }
            catch (OverflowException exception)
            {
                Console.WriteLine($"Число слишком большое: {exception.Message}");
                Console.WriteLine("Повторите ввод животного заново.");
                Console.WriteLine();
            }
        }
    }

    private static void PrintAnimals(Animal[] animals)
    {
        Console.WriteLine();
        Console.WriteLine("Созданные животные:");

        foreach (Animal animal in animals)
        {
            animal.Talk();
            animal.PrintProperties();
            Console.WriteLine(new string('-', 40));
        }
    }

    private static string ReadRequiredString(string prompt)
    {
        Console.Write(prompt);
        string? value = Console.ReadLine();

        if (value is null)
        {
            throw new InvalidOperationException("Ввод завершен.");
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Строка не может быть пустой.");
        }

        return value.Trim();
    }

    private static int ReadInt(string prompt, int minValue, int? maxValue = null)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (input is null)
        {
            throw new InvalidOperationException("Ввод завершен.");
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Число не может быть пустым.");
        }

        if (!int.TryParse(input, out int value))
        {
            throw new FormatException("Введите корректное целое число.");
        }

        if (value < minValue || (maxValue.HasValue && value > maxValue.Value))
        {
            string maxText = maxValue.HasValue ? $" до {maxValue.Value}" : string.Empty;
            throw new ArgumentException($"Введите число от {minValue}{maxText}.");
        }

        return value;
    }

    private static double ReadDouble(string prompt, double minValue, double? maxValue = null)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (input is null)
        {
            throw new InvalidOperationException("Ввод завершен.");
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Число не может быть пустым.");
        }

        if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value) &&
            !double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
        {
            throw new FormatException("Введите корректное число.");
        }

        if (value < minValue || (maxValue.HasValue && value > maxValue.Value))
        {
            string maxText = maxValue.HasValue ? $" до {maxValue.Value}" : string.Empty;
            throw new ArgumentException($"Введите число от {minValue}{maxText}.");
        }

        return value;
    }

    private static bool ReadBool(string prompt)
    {
        string input = ReadRequiredString(prompt).ToLower();

        return input switch
        {
            "да" or "д" or "yes" or "y" or "true" or "1" => true,
            "нет" or "н" or "no" or "n" or "false" or "0" => false,
            _ => throw new FormatException("Введите да или нет.")
        };
    }
}
