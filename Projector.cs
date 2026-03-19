public class Projector : Sprzet
{
    public int jasnoscLumeny { get; set; }
    public string maksymalnaRozdzielczosc { get; set; }
    public Projector(string name, 
        string status,
        string producent,
        decimal cena,
        int rokProdukcji,
        int jasnoscLumeny,
        string maksymalnaRozdzielczosc) : base(name, status,  producent, cena, rokProdukcji)
    {
        this.jasnoscLumeny = jasnoscLumeny;
        this.maksymalnaRozdzielczosc = maksymalnaRozdzielczosc;
    }
}