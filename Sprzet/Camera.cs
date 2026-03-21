public class Camera : Sprzet
{
    public string rozdzielczosc { get; set; }
    public string typMatrycy { get; set; }
    public string mocowanie { get; set; }
    public Camera(string name, 
        StatusSprzet status,
        string producent,
        decimal cena,
        int rokProdukcji,
        string rozdzielczosc, 
        string typMatrycy,
        string mocowanie) : base(name, status,  producent, cena, rokProdukcji)
    {
        this.rozdzielczosc = rozdzielczosc;
        this.typMatrycy = typMatrycy;
        this.mocowanie = mocowanie;
    }
}