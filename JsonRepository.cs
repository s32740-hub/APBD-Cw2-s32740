using System.Text.Json;

public abstract class JsonRepository<T>
{
    public void Zapisz(List<T> dane, string sciezka)
    {
        try
        {
            string? folder = Path.GetDirectoryName(sciezka);
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string json = JsonSerializer.Serialize(dane, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(sciezka, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd zapisu {typeof(T).Name}: {ex.Message}");
        }
    }

    public List<T> Wczytaj(string sciezka)
    {
        if (!File.Exists(sciezka)) return new List<T>();
        
        try
        {
            string json = File.ReadAllText(sciezka);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }
}