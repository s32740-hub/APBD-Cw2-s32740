namespace Wypozyczalnia;

public class UzytkownikManager
{
    public List<Uzytkownik> Uzytkownicy { get; private set; } = new List<Uzytkownik>();

    public void AddUzytkownik(Uzytkownik uzytkownik)
    {
        if (uzytkownik != null)
        {
            this.Uzytkownicy.Add(uzytkownik);
        }
    }

    public void WyswietlUzytkownikow()
    {
        foreach (var u in Uzytkownicy)
        {
            Console.WriteLine($"{u.UserId}: {u.Name} {u.Nazwisko} ({u.TypUzytkownika})");
        }
    }
}