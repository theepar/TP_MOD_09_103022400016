using System.Text.Json;

public class CovidConfig
{
    private const string ConfigFilePath = "covid_config.json";

    public string satuan_suhu { get; set; } = "celcius";
    public int batas_hari_deman { get; set; } = 14;
    public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    public CovidConfig()
    {
    }

    public void Load()
    {
        if (!File.Exists(ConfigFilePath))
        {
            Save();
            return;
        }

        try
        {
            string json = File.ReadAllText(ConfigFilePath);
            var data = JsonSerializer.Deserialize<CovidConfig>(json);

            if (data != null)
            {
                satuan_suhu = data.satuan_suhu;
                batas_hari_deman = data.batas_hari_deman;
                pesan_ditolak = data.pesan_ditolak;
                pesan_diterima = data.pesan_diterima;
            }
        }
        catch
        {
            Save();
        }
    }

    public void Save()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(ConfigFilePath, json);
    }

    public void UbahSatuan()
    {
        satuan_suhu = satuan_suhu.ToLower() == "celcius" ? "fahrenheit" : "celcius";
        Save();
    }
}