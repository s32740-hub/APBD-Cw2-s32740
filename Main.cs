using System;
using Wypozyczalnia;
WypozeczenieManager managerWyp = new WypozeczenieManager();
SprzetManager managerSprzet = new SprzetManager();
UzytkownikManager managerUzytkownik = new UzytkownikManager();

managerWyp.WczytajDane();
managerUzytkownik.WczytajDane();
managerSprzet.WczytajDane();
Console.WriteLine("Czy chcesz wykonać operację interaktywne?");
string odpowiedz = Console.ReadLine();
if (odpowiedz.ToLower() == "tak")
{
    bool dziala = true;
    while (dziala)
    {
        Console.Clear();
        Console.WriteLine("=== SYSTEM WYPOŻYCZALNI ===");
        Console.WriteLine("1. Wypożycz sprzęt");
        Console.WriteLine("2. Zwróć sprzęt (Oddaj)");
        Console.WriteLine("3. Raport: Stan Wypożyczalni");
        Console.WriteLine("4. Raport: Tylko przeterminowane");
        Console.WriteLine("5. DODAJ NOWY SPRZĘT");
        Console.WriteLine("6. DODAJ NOWEGO UŻYTKOWNIKA");
        Console.WriteLine("7. Wyświetl wszystkich użytkowników");
        Console.WriteLine("8. Wyświetl cały sprzęt");
        Console.WriteLine("9. Zapisz i Wyjdź");
        Console.Write("\nWybierz opcję: ");

        switch (Console.ReadLine())
        {
            case "1":
                DodajWypozyczenie(managerWyp, managerUzytkownik, managerSprzet);
                Console.ReadKey();
                break;

            case "2":
                Console.Write("Podaj ID sprzętu do zwrotu: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                    managerWyp.ZakonczWypozyczenie(id);
                Console.ReadKey();
                break;

            case "3":
                managerWyp.WygenerowacRaport();
                Console.ReadKey();
                break;

            case "4":
                Console.WriteLine("--- TYLKO PRZETERMINOWANE ---");
                managerWyp.WypiszPrzeterminowane();
                Console.ReadKey();
                break;

            case "5":
                DodajSprzetInteraktywnie(managerSprzet);
                break;

            case "6":
                DodajUzytkownikaInteraktywnie(managerUzytkownik);
                break;

            case "7":
                managerUzytkownik.WyswietlUzytkownikow();
                Console.ReadKey();
                break;

            case "8":
                managerSprzet.GetSprzet();
                Console.ReadKey();
                break;

            case "9":
                dziala = false;
                break;

            default:
                Console.WriteLine("Niepoprawny wybór!");
                Thread.Sleep(1000);
                break;
        }
    }
}
else
{
    Przyklad(managerSprzet, managerUzytkownik, managerWyp);
}
managerWyp.ZapiszDane();
managerSprzet.ZapiszDane();
managerUzytkownik.ZapiszDane();

static void Przyklad(SprzetManager managerSprzet, UzytkownikManager managerUzytkownik, WypozeczenieManager managerWyp)
{
    Thread.Sleep(1000);
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

    managerSprzet.AddSprzet(laptop);
    managerSprzet.AddSprzet(projektor);
    managerSprzet.AddSprzet(kamera);

    Student student = new Student(
        "Jan", "Kowalski"
    );
    Pracownik pracownik = new Pracownik(
        "Mateusz", "Kowalski"
    );
    managerUzytkownik.AddUzytkownik(student);
    managerUzytkownik.AddUzytkownik(pracownik);
    projektor.Uszkodzenie();
    //ERROR: nie można wypożyczyć sprzętu
    // wypozeczenieManager.AddWypozyczenie(
    //     student,
    //     projektor,
    //     null,
    //     null
    // );
    managerWyp.AddWypozyczenie(
        student,
        laptop,
        null,
        null
    );
    managerWyp.AddWypozyczenie(
        student,
        kamera,
        null,
        null
    );
    managerWyp.ZakonczWypozyczenie(laptop.sprzetID, DateTime.Now.AddDays(3));
    //Nalicza się Kara
    managerWyp.ZakonczWypozyczenie(kamera.sprzetID, DateTime.Now.AddDays(12));

    Console.WriteLine("Wszystkie sprzęty");
    managerSprzet.GetSprzet();

    Console.WriteLine("\nTylko dostępne sprzęty");
    managerSprzet.GetSprzetDostepny();

    Console.WriteLine("\nRaport:");
    managerWyp.WygenerowacRaport();
}

static void DodajWypozyczenie(WypozeczenieManager wm, UzytkownikManager um, SprzetManager sp)
{
    Console.Clear();
    Console.WriteLine("--- DODAWANIE Wypozyczenia ---");
    um.WyswietlUzytkownikow();
    Console.Write("ID Użytkownika: "); int uzytkownikID = int.Parse(Console.ReadLine());
    sp.GetSprzetDostepny();
    Console.Write("ID Sprżetu: "); int sprzetID = int.Parse(Console.ReadLine());
    Console.Write("Data Wypożyczenia: "); DateTime? dataWypozyczenia = DateTime.Parse(Console.ReadLine());
    Console.Write("Termin Zwrotu: "); DateTime? terminZwrotu = DateTime.Parse(Console.ReadLine());
    Uzytkownik uzytkownik = um.GetUzytkownik(uzytkownikID);
    Sprzet sprzet = sp.GetSprzet(sprzetID);
    wm.AddWypozyczenie(uzytkownik, sprzet, terminZwrotu, dataWypozyczenia);
    Console.WriteLine("Wypożyczenie dodane pomyślnie!");
    Console.ReadKey();
}

static void DodajSprzetInteraktywnie(SprzetManager sm)
{
    Console.Clear();
    Console.WriteLine("--- DODAWANIE SPRZĘTU ---");
    Console.WriteLine("1. Laptop | 2. Kamera | 3. Projektor");
    string typ = Console.ReadLine();

    Console.Write("Nazwa: "); string nazwa = Console.ReadLine();
    Console.Write("Producent: "); string prod = Console.ReadLine();
    Console.Write("Cena: "); decimal cena = decimal.Parse(Console.ReadLine());
    Console.Write("Rok produkcji: "); int rok = int.Parse(Console.ReadLine());

    if (typ == "1") {
        Console.Write("Procesor: "); string cpu = Console.ReadLine();
        Console.Write("OS: "); string os = Console.ReadLine();
        Console.Write("Wielkość RAM: "); int ram = int.Parse(Console.ReadLine());
        
        sm.AddSprzet(new Laptop(nazwa, StatusSprzet.Dostepny, prod, cena, rok, cpu, ram, os));
    }
    else if (typ == "2") {
        Console.Write("Rozdzielczość: "); string res = Console.ReadLine();
        Console.Write("Typ Matrycy: "); string matryca = Console.ReadLine();
        Console.Write("Mocowanie: "); string mocowanie = Console.ReadLine();
        
        sm.AddSprzet(new Camera(nazwa, StatusSprzet.Dostepny, prod, cena, rok, res, matryca, mocowanie));
    }
    else if (typ == "3") {
        Console.Write("Lumeny: "); int lum = int.Parse(Console.ReadLine());
        Console.Write("Maksymalna Rozdzielczość: "); string rozdzielczosc = Console.ReadLine();
        sm.AddSprzet(new Projector(nazwa, StatusSprzet.Dostepny, prod, cena, rok, lum, rozdzielczosc));
    }
    Console.WriteLine("Sprzęt dodany pomyślnie!");
    Console.ReadKey();
}
static void DodajUzytkownikaInteraktywnie(UzytkownikManager um)
{
    Console.Clear();
    Console.WriteLine("--- DODAWANIE UŻYTKOWNIKA ---");
    Console.WriteLine("1. Student | 2. Pracownik");
    string typ = Console.ReadLine();

    Console.Write("Imię: "); string imie = Console.ReadLine();
    Console.Write("Nazwisko: "); string nazwisko = Console.ReadLine();

    if (typ == "1") um.AddUzytkownik(new Student(imie, nazwisko));
    else um.AddUzytkownik(new Pracownik(imie, nazwisko));

    Console.WriteLine("Użytkownik zarejestrowany!");
    Console.ReadKey();
}