namespace Wypozyczalnia;

public class Wypozyczenie
{
    public Uzytkownik Uzytkownik { get; private set; }
    public Sprzet Sprzet { get; private set; }
    public DateTime? DataWypozyczenia { get; private set; }
    public DateTime? TerminZwrotu { get; private set; }
    public DateTime? DataFaktycznegoZwrotu { get; private set; }
    public decimal NaliczonaKara { get; private set; } = 0;
    private static decimal DziennaKara = 10;

    public Wypozyczenie(Uzytkownik uzytkownik, Sprzet sprzet, 
        DateTime? dataWypozyczenia, DateTime? terminZwrotu)
    {
        if (sprzet.status != StatusSprzet.Dostepny)
        {
            throw new InvalidOperationException(
                $"Nie można wypożyczyć sprzętu {sprzet.name}, ponieważ ma status: {sprzet.status}");
        }
        this.DataWypozyczenia = dataWypozyczenia ?? DateTime.Now;
        this.TerminZwrotu = terminZwrotu ?? this.DataWypozyczenia.Value.AddDays(7);
        this.Uzytkownik = uzytkownik;
        this.Sprzet = sprzet;
        this.Sprzet.status = StatusSprzet.Wypozyczony;
    }

    public void Zwrot(DateTime? dataZwrotu)
    {
        DataFaktycznegoZwrotu = dataZwrotu ?? DateTime.Now;
        Sprzet.status = StatusSprzet.Dostepny;
        if (this.DataFaktycznegoZwrotu > this.TerminZwrotu)
        {
            TimeSpan Roznica = DataFaktycznegoZwrotu.Value - TerminZwrotu.Value;
            int dni = Roznica.Days;
            if (dni > 0)
            {
                this.NaliczonaKara = dni * DziennaKara;
            }
        }
    }

    public override string ToString()
    {
        return $"Użytkownik: {Uzytkownik.Name} {Uzytkownik.Nazwisko}," +
               $"\n Sprzęt: {Sprzet}," +
               $"\n Data Wypożyczenia: {DataWypozyczenia}," +
               $"\n Termin Zwrotu: {TerminZwrotu}," +
               $"\n Data Faktycznego Zwrotu: {DataFaktycznegoZwrotu}," +
               $"\n Naliczona Kara: {NaliczonaKara}";
    }
}