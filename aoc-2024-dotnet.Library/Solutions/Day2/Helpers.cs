using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace aoc_2024_dotnet.Library.Solutions.Day2;

public class Helpers
{

    public static void PrintFileData(FileData data) {
        foreach (var report in data.Reports)
        {
            Console.Write("[ ");
            for (int i = 0; i < report.Count(); i++)
            {
                Console.Write($"{((i < report.Count() - 1) ? $"{report.ElementAt(i)}, " : $"{report.ElementAt(i)}")}");
            }
            Console.WriteLine(" ]");
        }
    }

    public static FileData ParseFileData(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        FileData fileData = new FileData {
            Reports = new List<IEnumerable<int>>()
        };

        string? line = reader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {

            var report = line.Split(" ", StringSplitOptions.None).ToList();
            if(report != null) {
                fileData.Reports.Add(report.Select(s => Int32.Parse(s)));
            }

            line = reader.ReadLine();
        }
        return fileData;
    }


}