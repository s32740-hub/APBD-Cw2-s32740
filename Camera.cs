public class Camera : Sprzet
{
    public string rozdzielczosc { get; set; }
    public string typMatrycy { get; set; }
    public string mocowanie { get; set; }
    public Camera(string name, 
        string status, 
        string rozdzielczosc, 
        string typMatrycy,
        string mocowanie) : base(name, status)
    {
        this.rozdzielczosc = rozdzielczosc;
        this.typMatrycy = typMatrycy;
        this.mocowanie = mocowanie;
    }
}