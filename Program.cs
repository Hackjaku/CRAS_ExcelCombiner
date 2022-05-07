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
        
    }

}
