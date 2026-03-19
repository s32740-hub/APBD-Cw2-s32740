public abstract class Sprzet
{
    private static int licznikSprzetu = 0;
    public string name { get; set; };
    public string status { get; set; };
    public int sprzetID { get; private set; };
    public string producent { get; set; }
    public decimal cena { get; set; }
    public int rokProdukcji { get; set; }

    protected Sprzet(string name,
        string status,
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
}