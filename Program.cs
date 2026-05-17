using BPO_3.Models;

namespace BPO_3;

class Program
{
    static void Main()
    {
        // Абстрактные классы Animal и Artiodactyl нельзя создать напрямую,
        // поэтому в массив помещаются только объекты конкретных классов
        Animal[] animals =
        [
            new Cow("Буренка", 5, 480, "коричневая", true),
            new Dog("Шарик", 3, 24, "дворняга"),
            new Horse("Гром", 7, 560, "вороная"),
            new Cat("Мурка", 2, 4.5, "серая")
        ];

        foreach (Animal animal in animals)
        {
            animal.Talk();
            animal.PrintProperties();
            Console.WriteLine(new string('-', 40));
        }
    }
}
