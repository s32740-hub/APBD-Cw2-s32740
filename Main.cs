using System;

SprzetManager manager = new SprzetManager();

Laptop mojLaptop = new Laptop(
    "Dell XPS",
    StatusSprzet.Dostepny,
    "Dell",
    6500.00m,
    2023,
    "Intel i7",
    16,
    "Windows 11"
);

manager.AddSprzet(mojLaptop);

Console.WriteLine("Wszystkie sprzęty");
manager.GetSprzet();

Console.WriteLine("\nTylko dostępne sprzęty");
manager.GetSprzetDostepny();