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

        public static void WriteRecords<T>(string file, IEnumerable<T> records)
        {
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

            var map = new DefaultClassMap<T>();

            map.AutoMap(CultureInfo.InvariantCulture);

            foreach (var memberMap in map.MemberMaps)
                memberMap.Data.Names.Add(memberMap.Data.Member!.Name.ToSnakeCase());

            csv.Context.RegisterClassMap(map);

            csv.WriteHeader<T>();
            csv.NextRecord();

            foreach (var record in records)
            {
                csv.WriteRecord(record);
                csv.NextRecord();
            }

            csv.Flush();
        }
    }
}