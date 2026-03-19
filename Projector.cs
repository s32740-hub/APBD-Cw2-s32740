public class Projector : Sprzet
{
    public int jasnoscLumeny { get; set; }
    public string maksymalnaRozdzielczosc { get; set; }
    public Projector(string name, 
        string status, 
        int jasnoscLumeny, 
        string maksymalnaRozdzielczosc) : base(name, status)
    {
        this.jasnoscLumeny = jasnoscLumeny;
        this.maksymalnaRozdzielczosc = maksymalnaRozdzielczosc;
    }
}