namespace Wypozyczalnia;

public class Pracownik : Uzytkownik
{
    public Pracownik(string name, string nazwisko) : 
        base(name, nazwisko, "Employee"){}
}