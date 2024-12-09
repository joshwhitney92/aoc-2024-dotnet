using aoc_2024_dotnet.Library.Day1;

namespace aoc_2024_dotnet.Driver;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution s = new Solution("./Assets/Day1.txt");
        Console.WriteLine($"Solution 1 Total is : {s.Solve()}");
        Console.WriteLine($"Solution 2 Total is : {s.Solve2()}");
    }
}
