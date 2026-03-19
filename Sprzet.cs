public abstract class Sprzet
{
    private static int licznikSprzetu = 0;
    public string name { get; set; };
    public string status { get; set; };
    public int sprzetID { get; private set; };

    protected Sprzet(string name, string status)
    {
        this.name = name;
        this.status = status;
        this.sprzetID = licznikSprzetu++;
    }
}
//feat: create abstract Sprzet class with auto-ID generation