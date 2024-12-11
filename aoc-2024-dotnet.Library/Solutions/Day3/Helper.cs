namespace aoc_2024_dotnet.Library.Solutions.Day3;

public static class Helper
{

    public static IEnumerable<string> ReadToList(string filepath)
    {
        StreamReader reader = new StreamReader(filepath);
        ICollection<string> lines = new List<string>();

        string line = reader.ReadLine();
        while (!String.IsNullOrEmpty(line))
        {
            lines.Add(line);
            line = reader.ReadLine();
        }

        return lines;
    }


}