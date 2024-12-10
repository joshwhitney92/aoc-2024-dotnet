using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

namespace aoc_2024_dotnet.Library.Solutions.Day2;

public static class Helpers
{

    private static readonly StringBuilder _sb = new StringBuilder();

    public static void PrintFileData(FileData data)
    {
        foreach (var report in data.Reports)
        {
            Console.WriteLine(EnumerableToString(',', report));
        }
    }

    public static string EnumerableToString(char delimiter, IEnumerable<int> list, bool outputBrackets = true)
    {
        _sb.Clear();
        
        if (outputBrackets) { _sb.Append("[ "); }
        for (int i = 0; i < list.Count(); i++)
        {
            _sb.Append($"{((i < list.Count() - 1) ? $"{list.ElementAt(i)}{delimiter.ToString()}" : $"{list.ElementAt(i)}")}");
        }
        if (outputBrackets)  {_sb.AppendLine(" ]"); }

        return _sb.ToString();
    }

    public static void OutputUnsafeRecordsToFile(ICollection<IEnumerable<int>> unsafeRecords)
    {
        string outputFileName = "output.txt";
        StreamWriter writer = new StreamWriter(outputFileName);
        foreach (var record in unsafeRecords)
        {
            writer.WriteLine(EnumerableToString(' ', record, outputBrackets: false));
        }

        writer.Flush();
    }
    public static FileData ParseFileData(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        FileData fileData = new FileData
        {
            Reports = new List<IEnumerable<int>>()
        };

        string? line = reader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {

            var report = line.Split(" ", StringSplitOptions.None).ToList();
            if (report != null)
            {
                fileData.Reports.Add(report.Select(s => Int32.Parse(s)));
            }

            line = reader.ReadLine();
        }
        return fileData;
    }


}