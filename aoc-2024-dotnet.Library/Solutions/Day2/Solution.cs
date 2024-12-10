// --- Day 2: Red-Nosed Reports ---
// 
// Fortunately, the first location The Historians want to search isn't a long
// walk from the Chief Historian's office.
// 
// While the Red-Nosed Reindeer nuclear fusion/fission plant appears to contain
// no sign of the Chief Historian, the engineers there run up to you as soon as
// they see you. Apparently, they still talk about the time Rudolph was saved
// through molecular synthesis from a single electron.
// 
// They're quick to add that - since you're already here - they'd really
// appreciate your help analyzing some unusual data from the Red-Nosed reactor.
// You turn to check if The Historians are waiting for you, but they seem to
// have already divided into groups that are currently searching every corner of
// the facility. You offer to help with the unusual data.
// 
// The unusual data (your puzzle input) consists of many reports, one report per
// line. Each report is a list of numbers called levels that are separated by
// spaces. For example:
// 
// 7 6 4 2 1
// 1 2 7 8 9
// 9 7 6 2 1
// 1 3 2 4 5
// 8 6 4 4 1
// 1 3 6 7 9
// 
// This example data contains six reports each containing five levels.
// 
// The engineers are trying to figure out which reports are safe. The Red-Nosed
// reactor safety systems can only tolerate levels that are either gradually
// increasing or gradually decreasing. So, a report only counts as safe if both
// of the following are true:
// 
//     The levels are either all increasing or all decreasing.
//     Any two adjacent levels differ by at least one and at most three.
// 
// In the example above, the reports can be found safe or unsafe by checking those rules:
// 
//     7 6 4 2 1: Safe because the levels are all decreasing by 1 or 2.
//     1 2 7 8 9: Unsafe because 2 7 is an increase of 5.
//     9 7 6 2 1: Unsafe because 6 2 is a decrease of 4.
//     1 3 2 4 5: Unsafe because 1 3 is increasing but 3 2 is decreasing.
//     8 6 4 4 1: Unsafe because 4 4 is neither an increase or a decrease.
//     1 3 6 7 9: Safe because the levels are all increasing by 1, 2, or 3.
// 
// So, in this example, 2 reports are safe.
// 
// Analyze the unusual data from the engineers. How many reports are safe?

using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace aoc_2024_dotnet.Library.Solutions.Day2;

public class Solution
{

    public Solution()
    {
    }

    public bool IsWithinBounds(int a, int b)
    {
        var difference = Math.Abs(a - b);
        return difference >= 1 && difference <= 3;
    }

    public bool IsIncreasing(IEnumerable<int> data)
    {
        for (int i = 0, j = i + 1; i < data.Count() - 1; i++, j++)
        {
            if ((data.ElementAt(i) > data.ElementAt(j)) ||
                !IsWithinBounds(data.ElementAt(i), data.ElementAt(j)))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsDecreasing(IEnumerable<int> data)
    {
        for (int i = 0, j = i + 1; i < data.Count() - 1; i++, j++)
        {
            if ((data.ElementAt(i) < data.ElementAt(j)) ||
                !IsWithinBounds(data.ElementAt(i), data.ElementAt(j)))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsSafe(IEnumerable<int> report)
    {
        return IsIncreasing(report) || IsDecreasing(report);
    }

    // O(n)
    // This is the better solution. Only need to iterate once.
    public bool IsSafeAlt(IEnumerable<int> report)
    {
        int? direction = null;
        for (int i = 1; i < report.Count(); i++)
        {

            var diff = report.ElementAt(i) - report.ElementAt(i - 1);

            // Differences must be between [1, 3]
            if (diff < -3 || diff > 3 || diff == 0)
            {
                return false;
            }

            // Check the direction
            var currentDirection = diff > 0 ? 1 : -1;
            if (direction == null)
            {
                direction = currentDirection;
            }
            else if (currentDirection != direction)
            {
                return false;
            }

        }

        return true;
    }


    // Computes whether a `report` can be made safe by removing a level.
    public bool IsSafeWithDampener(IEnumerable<int> report)
    {
        for(int i = 0; i < report.Count(); i ++) {
            // Check if array can be safe by removing `i`.
            var modified = report.Where((item, index) => index != i );
            if(IsSafe(modified)) {
                return true;
            }
        }

        return false;
    }


    public int SolveWithDampener(FileData contents)
    {
        List<IEnumerable<int>> unsafeReports = new List<IEnumerable<int>>();
        int safeCount = 0;

        foreach (var report in contents.Reports)
        {
            if (IsSafeWithDampener(report) || IsSafeWithDampener(report))
            {
                safeCount += 1;
            }
            // FOR DEBUGGING ONLY!
            else
            {
                unsafeReports.Add(report);
            }
        }

        Helpers.OutputUnsafeRecordsToFile("output_dampened.txt", unsafeReports);

        // ANSWER: 
        return safeCount;
    }


    public int Solve(FileData contents)
    {
        List<IEnumerable<int>> unsafeReports = new List<IEnumerable<int>>();
        int safeCount = 0;

        foreach (var report in contents.Reports)
        {
            // if (IsSafe(report))
            if (IsSafeAlt(report))
            {
                safeCount += 1;
            }
            // FOR DEBUGGING ONLY!
            else
            {
                unsafeReports.Add(report);
            }
        }

        Helpers.OutputUnsafeRecordsToFile("output.txt", unsafeReports);

        // ANSWER: 479
        return safeCount;
    }

}