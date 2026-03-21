namespace Wypozyczalnia;

public abstract class Uzytkownik
{
    private static int LicznikUzytkownikow = 0;
    public int UserId { get; private set; }
    public string Name { get; }
    public string Nazwisko { get; }
    public string TypUzytkownika { get; protected set; }

    public Uzytkownik(string name, string nazwisko, string typUzytkownika)
    {
        this.Name = name;
        this.Nazwisko = nazwisko;
        this.TypUzytkownika = typUzytkownika;
        this.UserId = LicznikUzytkownikow++;
    }
}