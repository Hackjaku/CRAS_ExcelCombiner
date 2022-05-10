using System.Linq;
using ExcelCombiner;

List<Trip> recuperi = Utilities.GetTripCSV("recuperi.csv", true);
List<Animal> animali = Utilities.GetAnimalsCSV("animali.csv");
List<Trip> liberazioni = Utilities.GetTripCSV("liberazioni.csv", false);

foreach (var animal in animali) {
    var liberazione = liberazioni.FirstOrDefault(x => animal.Progressive == x.Progressive);
    var recupero = recuperi.FirstOrDefault(x => animal.Progressive == x.Progressive);
    var csvLine = Utilities.GetCSVLine(animal, recupero!, liberazione);
    if (animal.Tipology != "non rendicontabile") {
        await Utilities.WriteLine(csvLine);
    }
}

Console.WriteLine("Fatto");



namespace ExcelCombiner {
    public static class Utilities {

        public static List<Trip> GetTripCSV(string path, bool vehicle = false) {
            List<Trip> trips = new();
            using var reader = new StreamReader(path);
            while(!reader.EndOfStream) {
                string line = reader.ReadLine() ?? "";
                trips.Add(new Trip(line, vehicle));
            }
            return trips;
        }

        public static List<Animal> GetAnimalsCSV(string path) {
            List<Animal> animals = new();
            using var reader = new StreamReader(path);
            while (!reader.EndOfStream) {
                string line = reader.ReadLine() ?? "";
                animals.Add(new Animal(line));
            }
            return animals;
        }
        public static List<string> GetCSV(string filePath) {
            var result = new List<string>();
            using var reader = new StreamReader(filePath);
            while(!reader.EndOfStream) {
                // leggi il file
                result.Add(reader.ReadLine()!);
            }
            return result;
        }

        public static Task<int> WriteLine(string text) {
            try {
                string logPath = Path.Combine("merged.csv");
                if (!File.Exists(logPath)) {
                    using StreamWriter sw = File.CreateText(logPath);
                    sw.WriteLine(text);
                } else {
                    using StreamWriter sw = File.AppendText(logPath);
                    sw.WriteLine(text);
                }
                return Task.FromResult(0);
            } catch (Exception e) {
                Console.WriteLine("(WriteLog) " + e.Message);
                return Task.FromResult(1);
            }
        }

        public static string GetCSVLine(Animal animal, Trip rescue, Trip? liberation) {
            var line =  animal.Date + "|" +
                animal.Class + "|" +
                animal.Species + "|" +
                animal.Progressive + "|" +
                animal.CageNumber + "|" +
                animal.Tipology + "|" +
                animal.RescuerName + "|" +
                animal.RescuePlace + "|" +
                animal.Weight + "|" +
                animal.Gender + "|" +
                animal.Injured + "|" +
                animal.Diagnosis + "|" +
                animal.Theraphy + "|" +
                animal.LiberationDate + "|" +
                animal.DeathDate + "|" +
                animal.DeathCause + "|" +
                animal.Mode + "|" +
                animal.Place + "|" +
                animal.INFS + "|" +
                animal.Status + "|" +
                animal.RecoveryCause + "|" +
                animal.Destiny + "|" +
                animal.CarcassDisposer + "|" +
                rescue.Km + "|" +
                rescue.Latitude + "|" +
                rescue.Longitude + "|" +
                rescue.Vehicle + "|";
            if(liberation != null) {
                line +=
                liberation.Km + "|" +
                liberation.Latitude + "|" +
                liberation.Longitude;
            } else {
                line += "||";
            }
            return line;
        }

    }

    public class Trip {
        public int Progressive { get; set; }
        public string Km { get; set; }
        public string Species { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string Vehicle { get; set; }

        public Trip(string line, bool vehicle = false) {
            var values = line.Split('|');
            Progressive = int.Parse(values[0]);
            Species = values[1];
            Latitude = values[2];
            Longitude = values[3];
            Address = values[4];
            Date = values[5];
            Km = values[6];
            if(vehicle) {
                Vehicle = values[7];
            } else {
                Vehicle = "";
            }
        }

    }

    public class Animal {
        public string Date { get; set; }
        public string Class { get; set; }
        public string Species { get; set; }
        public int Progressive { get; set; }
        public string CageNumber { get; set; }
        public string Tipology { get; set; }
        public string RescuerName { get; set; }
        public string RescuePlace { get; set; }
        public string Weight { get; set; }
        public string Gender { get; set; }
        public string Injured { get; set; }
        public string Diagnosis { get; set; }
        public string Theraphy { get; set; }
        public string LiberationDate { get; set; }
        public string DeathDate { get; set; }
        public string DeathCause { get; set; }
        public string Mode { get; set; }
        public string Place { get; set; }
        public string INFS { get; set; }
        public string Status { get; set; }
        public string RecoveryCause { get; set; }
        public string Destiny { get; set; }
        public string CarcassDisposer { get; set; }

        public Animal(string line) {
            var values = line.Split('|');
            Date = values[0];
            Class = values[1];
            Species = values[2];
            Progressive = int.Parse(values[3]);
            CageNumber = values[4];
            Tipology = values[5];
            RescuerName = values[6];
            RescuePlace = values[7];
            Weight = values[8];
            Gender = values[9];
            Injured = values[10];
            Diagnosis = values[11];
            Theraphy = values[12];
            LiberationDate = values[13];
            DeathDate = values[14];
            DeathCause = values[15];
            Mode = values[16];
            Place = values[17];
            INFS = values[18];
            Status = values[19];
            RecoveryCause = values[20];
            Destiny = values[21];
            CarcassDisposer = values[22];
        }
    }

}
