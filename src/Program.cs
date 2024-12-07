// using aoc_2024_dotnet.Solutions.Day1;
using aoc_2024_dotnet.Solutions.Day2;

namespace aoc_2024_dotnet;

class Program
{
    static void Main(string[] args)
    {
        // Day 1 solutions.
        // Console.WriteLine("Hello, World!");
        // Solution s = new Solution("./problem_inputs/day_1.txt");
        // Console.WriteLine($"Solution 1 Total is : {s.Solve()}");
        // Console.WriteLine($"Solution 2 Total is : {s.Solve2()}");

        // Day 2 solutions.
        Solution s = new Solution("./problem_inputs/day_2.txt");
        Console.WriteLine($"Solution 1 Total is : {s.Solve()} safe reports.");
    }
}
