public class Laptop : Sprzet
{
    public string procesor { get; set; }
    public int wielkoscRAM { get; set; }
    public string OS{get; set;}
    public Laptop(string name, 
        StatusSprzet status,
        string producent,
        decimal cena,
        int rokProdukcji,
        string procesor,
        int wielkoscRAM,
        string OS) : base(name, status,  producent, cena, rokProdukcji)
    {
        this.wielkoscRAM = wielkoscRAM;
        this.OS = OS;
        this.procesor = procesor;
    }
}