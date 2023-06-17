using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;

string csvFilePath = @"C:\Users\nirmo\Downloads\annual-enterprise-survey-2021-financial-year-provisional-csv.csv";
string json = ConvertCsvToJson(csvFilePath);
Console.WriteLine(json);
Console.ReadLine();

#region Private Methods
static string ConvertCsvToJson(string csvFilePath)
{
    using (var reader = new StreamReader(csvFilePath))
    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
    {
        var records = csv.GetRecords<dynamic>();
        var json = JsonConvert.SerializeObject(records, Newtonsoft.Json.Formatting.Indented);
        return json;
    }
}
#endregion