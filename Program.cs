using System.IO;

List<string> recuperi = new List<string>();
List<string> liberazioni = new List<string>();
List<string> animali = new List<string>();



namespace ExcelCombiner {
    public static class Utilities {
        public static List<string> GetCSV(string filePath) {
            var result = new List<string>();
            using var reader = new StreamReader(filePath);
            while(!reader.EndOfStream) {
                // leggi il file
                result.Add(reader.ReadLine()!);
            }
            return result;
        }

    }

    public class Trip {
        int Progressive { get; set; }
        double Km { get; set; }

    }

    public class LiberationTrip : Trip {
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Address { get; set; }
        DateTime Date { get; set; }
    }

    public class Animal {
        public DateTime Date { get; set; }
        public string Class { get; set; }
        public string Species { get; set; }
        public int Progressive { get; set; }
        public string CageNumber { get; set; }
        public string Tipology { get; set; }
        public string RescuerName { get; set; }
        public string RescuePlace { get; set; }
        public double Weight { get; set; }
        public int Gender { get; set; }
        public int Injured { get; set; }
        public string Diagnosis { get; set; }
        public string Theraphy { get; set; }
        public DateTime LiberationDate { get; set; }
        public DateTime DeathDate { get; set; }
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
            Date = DateTime.Parse(values[0]);
            Class = values[1];
            Species = values[2];
            Progressive = int.Parse(values[3]);
            CageNumber = values[4];
            Tipology = values[5];
            RescuerName = values[6];
            RescuePlace = values[7];
            Weight = double.Parse(values[8]);
            Gender = int.Parse(values[9]);
            Injured = int.Parse(values[10]);
            Diagnosis = values[11];
            Theraphy = values[12];
            LiberationDate = DateTime.Parse(values[13]);
            DeathDate = DateTime.Parse(values[14]);
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
