public class Laptop : Sprzet
{
    public string procesor { get; set; }
    public int wielkoscRAM { get; set; }
    public string OS{get; set;}
    public Laptop(string name, 
        string status,
        string procesor,
        int wielkoscRAM,
        string OS) : base(name, status)
    {
        this.wielkoscRAM = wielkoscRAM;
        this.OS = OS;
        this.procesor = procesor;
    }
}