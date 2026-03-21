using System.Text.Json;

namespace Wypozyczalnia;

public class WypozeczenieManager:JsonRepository<Wypozyczenie>
{
    public List<Wypozyczenie> WszystkieWypozyczenia { get; private set; } = new List<Wypozyczenie>();
    private static int limitStudent = 2;
    private static int limitPracownik = 5;
    private static string plik = "dane/wypozyczenia.json";
    public void AddWypozyczenie(Uzytkownik uzytkownik, Sprzet sprzet, DateTime? terminZwrotu, DateTime ? dataWypozyczenia = null)
    {
        int aktywne = WszystkieWypozyczenia.Count(w => w.Uzytkownik.UserId == uzytkownik.UserId && 
                                                       w.DataFaktycznegoZwrotu == null);
        if (uzytkownik is Student && aktywne >= limitStudent || uzytkownik is Pracownik && aktywne>=limitPracownik)
        {
            throw new InvalidOperationException($"Nie można wypożyczyć sprzęt użytkownikowi " +
                                                $"{uzytkownik.Name}, ponieważ już przekroczył " +
                                                $"limit możliwych wypożyczeń.");
        }
        Wypozyczenie wypozyczenie = new Wypozyczenie(uzytkownik, sprzet, dataWypozyczenia, terminZwrotu);
        WszystkieWypozyczenia.Add(wypozyczenie);
        Console.WriteLine($"Użytkownik {uzytkownik.Name} wypożyczył sprzęt {sprzet.name}");
    }
    public void ZakonczWypozyczenie(int idSprzetu, DateTime? dataFaktycznegoZwrotu = null)
    {
        var wypozyczenie = WszystkieWypozyczenia.FirstOrDefault(w => 
            w.Sprzet.sprzetID == idSprzetu && w.DataFaktycznegoZwrotu == null);

        if (wypozyczenie == null)
        {
            throw new InvalidOperationException($"Nie znaleziono aktywnego wypożyczenia dla sprzętu o ID: {idSprzetu}");
        }

        wypozyczenie.Zwrot(dataFaktycznegoZwrotu);

        Console.WriteLine($"[ZWRÓCONO] {wypozyczenie.Sprzet.name}. Kara: {wypozyczenie.NaliczonaKara} PLN");
    }

    public void WypiszAktywneWypozyczenia(Uzytkownik uzytkownik)
    {
        WszystkieWypozyczenia.Where(w=>w.Uzytkownik.UserId == uzytkownik.UserId 
                                       &&  w.DataFaktycznegoZwrotu == null).ToList()
            .ForEach(w=> Console.WriteLine(w));
    }

    public void WypiszPrzeterminowane()
    {
        WszystkieWypozyczenia.Where(w=> w.DataFaktycznegoZwrotu == null && DateTime.Now > w.TerminZwrotu).ToList()
            .ForEach(w=> Console.WriteLine(w));
    }

    public void WygenerowacRaport()
    {
        int IloscAktualnychWypozyczen = WszystkieWypozyczenia.Count(w => w.DataFaktycznegoZwrotu == null);
        int IloscPrzeterminiowanychWypozyczen = WszystkieWypozyczenia.Count(w=> w.DataFaktycznegoZwrotu == null && DateTime.Now > w.TerminZwrotu);
        int IloscWypozyczenZNaliczonaKara = WszystkieWypozyczenia.Count(w => w.NaliczonaKara != 0);
        int Wszystkie = WszystkieWypozyczenia.Count();
        
        Console.WriteLine("----STAN WYPOŻYCZALNI----");
        Console.WriteLine($"Ilość Wszystkich Wypożyczeń: {Wszystkie}");
        Console.WriteLine($"Ilość Aktualnych Wypożyczeń: {IloscAktualnychWypozyczen}");
        Console.WriteLine($"Ilość Przeterminiowanych Wypożyczeń: {IloscPrzeterminiowanychWypozyczen}");
        this.WypiszPrzeterminowane();
        Console.WriteLine($"Ilość Wypożyczeń Z Naliczoną Karą: {IloscWypozyczenZNaliczonaKara}");
        Console.WriteLine("Najstarsze wypożyczenia:");
        WszystkieWypozyczenia.Where(w=> w.DataWypozyczenia == (WszystkieWypozyczenia.Min(w => w.DataWypozyczenia)))
            .ToList().ForEach(w=>Console.WriteLine(w));
        Console.WriteLine("Najnowsze wypożyczenia:");
        WszystkieWypozyczenia.Where(w=> w.DataWypozyczenia == (WszystkieWypozyczenia.Max(w => w.DataWypozyczenia)))
            .ToList().ForEach(w=>Console.WriteLine(w));
    }
    public void ZapiszDane()
    {
        base.Zapisz(WszystkieWypozyczenia, plik);
    }

    public void WczytajDane()
    {
        WszystkieWypozyczenia = base.Wczytaj(plik);
    }
}