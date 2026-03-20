namespace Wypozyczalnia;

public class Wypozyczenie
{
    public Uzytkownik Uzytkownik { get; private set; }
    public Sprzet Sprzet { get; private set; }
    public DateTime DataWypozyczenia { get; private set; }
    public DateTime TerminZwrotu { get; private set; }
    public DateTime? DataFaktycznegoZwrotu { get; private set; }
    public decimal NaliczonaKara { get; private set; } = 0;

    public Wypozyczenie(Uzytkownik uzytkownik, Sprzet sprzet,
        DateTime dataWypozyczenia, DateTime terminZwrotu)
    {
        this.Uzytkownik = uzytkownik;
        this.Sprzet = sprzet;
        this.Sprzet.status = StatusSprzet.Wypozyczony;
        this.DataWypozyczenia = dataWypozyczenia;
        this.TerminZwrotu = terminZwrotu;
    }
    
}