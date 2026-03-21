using System.Text.Json;

namespace Wypozyczalnia;

public class UzytkownikManager:JsonRepository<Uzytkownik>
{
    public List<Uzytkownik> Uzytkownicy { get; private set; } = new List<Uzytkownik>();
    private static string plik = "dane/uzytkownicy.json";

    public void AddUzytkownik(Uzytkownik uzytkownik)
    {
        if (uzytkownik != null)
        {
            this.Uzytkownicy.Add(uzytkownik);
        }
    }

    public Uzytkownik? GetUzytkownik(int id)
    {
        return Uzytkownicy.FirstOrDefault(u => u.UserId == id);
    }

    public void WyswietlUzytkownikow()
    {
        foreach (var u in Uzytkownicy)
        {
            Console.WriteLine($"{u.UserId}: {u.Name}\n {u.Nazwisko}\n ({u.TypUzytkownika})");
        }
    }
    public void ZapiszDane()
    {
        base.Zapisz(Uzytkownicy, plik);
    }

    public void WczytajDane()
    {
        Uzytkownicy = base.Wczytaj(plik);
        if (Uzytkownicy.Any())
        {
            int maxId = Uzytkownicy.Max(s => s.UserId);
            Uzytkownik.UpdateNextId(maxId + 1);
        }
    }
}