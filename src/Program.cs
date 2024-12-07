using aoc_2024_dotnet.Day1;

namespace aoc_2024_dotnet;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution s = new Solution("./src/Day1/input.txt");
        Console.WriteLine($"Solution 1 Total is : {s.Solve()}");
        Console.WriteLine($"Solution 2 Total is : {s.Solve2()}");
    }
}
