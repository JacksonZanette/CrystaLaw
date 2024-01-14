using CrystaLaw.ConsoleApp.Infra.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CrystaLaw.ConsoleApp.Infra.Helpers
{
    public static class CSVParser
    {
        public static IEnumerable<T> GetRecords<T>(string file)
        {
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToPascalCase()
            });

            return csv.GetRecords<T>().ToArray();
        }
    }
}