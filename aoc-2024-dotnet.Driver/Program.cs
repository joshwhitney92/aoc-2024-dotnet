// using aoc_2024_dotnet.Library.Solutions.Day1;
using aoc_2024_dotnet.Library.Solutions.Day2;

namespace aoc_2024_dotnet.Driver;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // Solution s = new Solution("./Assets/Day1.txt");
        // Console.WriteLine($"Solution 1 Total is : {s.Solve()}");
        // Console.WriteLine($"Solution 2 Total is : {s.Solve2()}");

        // Day 2 solutions.
        Solution s = new Solution();
        FileData contents = Helpers.ParseFileData("./Assets/day_2.txt");
        Console.WriteLine($"Solution 1 Total is : {s.Solve(contents)} safe reports.");
        Console.WriteLine($"Solution with Dampener is: {s.SolveWithDampener(contents)} safe reports.");
    }
}
