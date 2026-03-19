public class SprzetManager
{
    public List<Sprzet> ListaSprzet { get; set; } = new List<Sprzet>();

    public void AddSprzet(Sprzet sprzet)
    {
        this.ListaSprzet.Add(sprzet);
    }

    public void GetSprzet()
    {
        this.ListaSprzet.ForEach(s => Console.WriteLine(
            $"Sprzęt: {s.name} Status: {s.status}"));
    }
    public void GetSprzetDostepny()
    {
        this.ListaSprzet.Where(s=>s.status.ToLower()=="dostepny").ToList()
            .ForEach(s => Console.WriteLine(
                $"[DOSTĘPNY] Sprzęt: {s.name}"));
    }
}