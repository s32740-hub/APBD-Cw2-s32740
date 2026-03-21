namespace Wypozyczalnia;

public class WypozeczenieManager
{
    public List<Wypozyczenie> WszystkieWypozyczenia { get; private set; } = new List<Wypozyczenie>();
    private static int limitStudent = 2;
    private static int limitPracownik = 5;
    void AddWypozyczenie(Uzytkownik uzytkownik, Sprzet sprzet, DateTime terminZwrotu, DateTime ? dataWypozyczenia = null)
    {
        int aktywne = WszystkieWypozyczenia.Count(w => w.Uzytkownik.UserId == uzytkownik.UserId && 
                                                       w.DataFaktycznegoZwrotu == null);
        if (uzytkownik is Student && aktywne > limitStudent || uzytkownik is Pracownik && aktywne>limitPracownik)
        {
            throw new InvalidOperationException($"Nie można wypożyczyć sprzęt użytkownikowi " +
                                                $"{uzytkownik.Name}, ponieważ już przekroczył " +
                                                $"limit możliwych wypożyczeń.");
        }
        DateTime dataStartu = dataWypozyczenia ?? DateTime.Now;
        Wypozyczenie wypozyczenie = new Wypozyczenie(uzytkownik, sprzet, dataStartu, terminZwrotu);
        WszystkieWypozyczenia.Add(wypozyczenie);
        Console.WriteLine($"Użytkownik {uzytkownik.Name} wypożyczył sprzęt {sprzet.name}");
    }

    void WypiszAktywneWypozyczenia(Uzytkownik uzytkownik)
    {
        WszystkieWypozyczenia.Where(w=>w.Uzytkownik.UserId == uzytkownik.UserId 
                                       &&  w.DataFaktycznegoZwrotu == null).ToList()
            .ForEach(w=> Console.WriteLine(w));
    }

    void WypiszPrzeterminiowane()
    {
        WszystkieWypozyczenia.Where(w=> w.DataFaktycznegoZwrotu > w.TerminZwrotu && 
                                        w.DataFaktycznegoZwrotu == null).ToList()
            .ForEach(w=> Console.WriteLine(w));
    }

    void WygenerowacRaport()
    {
        int IloscAktualnychWypozyczen = WszystkieWypozyczenia.Count(w => w.DataFaktycznegoZwrotu == null);
        int IloscPrzeterminiowanychWypozyczen = WszystkieWypozyczenia.Count(w=> w.DataFaktycznegoZwrotu > w.TerminZwrotu && 
            w.DataFaktycznegoZwrotu == null);
        int IloscWypozyczenZNaliczonaKara = WszystkieWypozyczenia.Count(w => w.NaliczonaKara != 0);
        int Wszystkie = WszystkieWypozyczenia.Count();
        
        Console.WriteLine("----STAN WYPOŻYCZALNI----");
        Console.WriteLine($"Ilość Wszystkich Wypożyczeń: {Wszystkie}");
        Console.WriteLine($"Ilość Aktualnych Wypożyczeń: {IloscAktualnychWypozyczen}");
        Console.WriteLine($"Ilość Przeterminiowanych Wypożyczeń: {IloscPrzeterminiowanychWypozyczen}");
        Console.WriteLine($"Ilość Wypożyczeń Z Naliczoną Karą: {IloscWypozyczenZNaliczonaKara}");
        Console.WriteLine("Najstarsze wypożyczenia:");
        WszystkieWypozyczenia.Where(w=> w.DataWypozyczenia == (WszystkieWypozyczenia.Min(w => w.DataWypozyczenia)))
            .ToList().ForEach(w=>Console.WriteLine(w));
        Console.WriteLine("Najnowsze wypożyczenia:");
        WszystkieWypozyczenia.Where(w=> w.DataWypozyczenia == (WszystkieWypozyczenia.Max(w => w.DataWypozyczenia)))
            .ToList().ForEach(w=>Console.WriteLine(w));
    }
}