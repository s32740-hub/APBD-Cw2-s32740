using System;
using Wypozyczalnia;

SprzetManager manager = new SprzetManager();

Laptop laptop = new Laptop(
    "Dell XPS",
    StatusSprzet.Dostepny,
    "Dell",
    6500.00m,
    2023,
    "Intel i7",
    16,
    "Windows 11"
);
Projector projektor = new Projector(
    "Epson EB-FH06",
    StatusSprzet.Dostepny,
    "Epson",
    2499.00m,
    2024,
    3500,
    "1920x1080"
);

Camera kamera = new Camera(
    "Sony Alpha A7 IV",
    StatusSprzet.Dostepny,
    "Sony",
    11200.00m,
    2025,
    "33 MP",
    "Pełna klatka",
    "Sony E"
);

manager.AddSprzet(laptop);
manager.AddSprzet(projektor);
manager.AddSprzet(kamera);

UzytkownikManager uzytkownikManager = new UzytkownikManager();
Student student = new Student(
    "Jan", "Kowalski"
);
Pracownik pracownik = new Pracownik(
    "Mateusz", "Kowalski"
);
uzytkownikManager.AddUzytkownik(student);
uzytkownikManager.AddUzytkownik(pracownik);
WypozeczenieManager wypozeczenieManager = new WypozeczenieManager();
projektor.Uszkodzenie();
//ERROR: nie można wypożyczyć sprzętu
// wypozeczenieManager.AddWypozyczenie(
//     student,
//     projektor,
//     null,
//     null
// );
wypozeczenieManager.AddWypozyczenie(
    student,
    laptop,
    null,
    null
);
wypozeczenieManager.AddWypozyczenie(
    student,
    kamera,
    null,
    null
);
wypozeczenieManager.ZakonczWypozyczenie(laptop.sprzetID,DateTime.Now.AddDays(3));
//Nalicza się Kara
wypozeczenieManager.ZakonczWypozyczenie(kamera.sprzetID,DateTime.Now.AddDays(12));

Console.WriteLine("Wszystkie sprzęty");
manager.GetSprzet();

Console.WriteLine("\nTylko dostępne sprzęty");
manager.GetSprzetDostepny();

Console.WriteLine("\nRaport:");
wypozeczenieManager.WygenerowacRaport();