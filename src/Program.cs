using aoc_2024_dotnet.Solutions.Day1;

namespace aoc_2024_dotnet;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution s = new Solution("./problem_inputs/day_1.txt");
        Console.WriteLine($"Solution 1 Total is : {s.Solve()}");
        Console.WriteLine($"Solution 2 Total is : {s.Solve2()}");
    }
}
