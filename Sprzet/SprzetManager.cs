using System.Text.Json;

public class SprzetManager:JsonRepository<Sprzet>
{
    public List<Sprzet> ListaSprzet { get; set; } = new List<Sprzet>();
    private static string plik = "dane/sprzet.json";

    public void AddSprzet(Sprzet sprzet)
    {
        this.ListaSprzet.Add(sprzet);
    }

    public void GetSprzet()
    {
        this.ListaSprzet.ForEach(s => Console.WriteLine(
            $"Sprzęt: {s.name} Status: {s.status}"));
    }
    public Sprzet? GetSprzet(int id)
    {
        return ListaSprzet.FirstOrDefault(s => s.sprzetID == id);
    }
    public void GetSprzetDostepny()
    {
        this.ListaSprzet.Where(s=>s.status==StatusSprzet.Dostepny).ToList()
            .ForEach(s => Console.WriteLine(
                $"[DOSTĘPNY] ID: {s.sprzetID}\nSprzęt: {s.name}"));
    }
    public void ZapiszDane()
    {
        base.Zapisz(ListaSprzet, plik);
    }

    public void WczytajDane()
    {
        ListaSprzet = base.Wczytaj(plik);
        if (ListaSprzet.Any())
        {
            int maxId = ListaSprzet.Max(s => s.sprzetID);
            Sprzet.UpdateNextId(maxId + 1);
        }
    }
}