using System.Text.Json.Serialization;
public enum StatusSprzet
{
    Dostepny,
    Wypozyczony,
    Niedostepny
}
[JsonDerivedType(typeof(Laptop), "laptop")]
[JsonDerivedType(typeof(Camera), "camera")]
[JsonDerivedType(typeof(Projector), "projector")]
public abstract class Sprzet
{
    private static int licznikSprzetu = 0;
    public string name { get; set; }
    public StatusSprzet status { get; set; }
    public int sprzetID { get; private set; }
    public string producent { get; set; }
    public decimal cena { get; set; }
    public int rokProdukcji { get; set; }

    protected Sprzet(string name,
        StatusSprzet status,
        string producent,
        decimal cena,
        int rokProdukcji)
    {
        this.name = name;
        this.status = status;
        this.sprzetID = licznikSprzetu++;
        this.producent = producent;
        this.cena = cena;
        this.rokProdukcji = rokProdukcji;
    }

    public void Uszkodzenie()
    {
        status = StatusSprzet.Niedostepny;
    }
    public static void UpdateNextId(int newId)
    {
        licznikSprzetu = newId;
    }
}