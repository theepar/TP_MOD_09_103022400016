CovidConfig config = new CovidConfig();
config.Load();

config.UbahSatuan();

Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
double suhu = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
int hariDeman = int.Parse(Console.ReadLine() ?? "0");

bool suhuValid = config.satuan_suhu.ToLower() == "celcius"
    ? suhu >= 36.5 && suhu <= 37.5
    : suhu >= 97.7 && suhu <= 99.5;

bool hariValid = hariDeman < config.batas_hari_deman;

Console.WriteLine(suhuValid && hariValid ? config.pesan_diterima : config.pesan_ditolak);