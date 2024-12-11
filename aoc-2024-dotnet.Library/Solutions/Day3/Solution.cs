// --- Day 3: Mull It Over ---
// 
// "Our computers are having issues, so I have no idea if we have any Chief
// Historians in stock! You're welcome to check the warehouse, though," says the
// mildly flustered shopkeeper at the North Pole Toboggan Rental Shop. The
// Historians head out to take a look.
// 
// The shopkeeper turns to you. "Any chance you can see why our computers are
// having issues again?"
// 
// The computer appears to be trying to run a program, but its memory (your
// puzzle input) is corrupted. All of the instructions have been jumbled up!
// 
// It seems like the goal of the program is just to multiply some numbers. It
// does that with instructions like mul(X,Y), where X and Y are each 1-3 digit
// numbers. For instance, mul(44,46) multiplies 44 by 46 to get a result of
// 2024. Similarly, mul(123,4) would multiply 123 by 4.
// 
// However, because the program's memory has been corrupted, there are also many
// invalid characters that should be ignored, even if they look like part of a
// mul instruction. Sequences like mul(4*, mul(6,9!, ?(12,34), or mul ( 2 , 4 )
// do nothing.
// 
// For example, consider the following section of corrupted memory:
// 
// xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
// 
// Only the four highlighted sections are real mul instructions. Adding up the
// result of each instruction produces 161 (2*4 + 5*5 + 11*8 + 8*5).
// 
// Scan the corrupted memory for uncorrupted mul instructions. What do you get
// if you add up all of the results of the multiplications?




using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace aoc_2024_dotnet.Library.Solutions.Day3;


public class Solution
{


    public long Solve2(string filepath)
    {
        StreamReader reader = new StreamReader(filepath);
        long result = 0;

        string? line = reader.ReadLine();
        string pattern = @"(do[n\'t]*\(\))[^do]*";
        int? firstMatchIndex = null;
        while (!string.IsNullOrEmpty(line))
        {
            foreach (Match match in Regex.Matches(line, pattern, RegexOptions.None))
            {
                if (firstMatchIndex == null) { firstMatchIndex = match.Index; }

                var groups = match.Groups;
                if (string.Equals(groups[1].Value, @"do()", StringComparison.InvariantCultureIgnoreCase))
                {
                    result += MultiplyAndSumGroups(match.Value);
                }
            }

            // Add in the prefix
            var prefix = line.Substring(0, firstMatchIndex.GetValueOrDefault());
            result += MultiplyAndSumGroups(prefix);

            line = reader.ReadLine();
        }
        return result;
    }

    public int MultiplyAndSumGroups(string line)
    {
        int sum = 0;
        string pattern = @"mul\(\b(\d{1,3})\b,\b(\d{1,3})\b\)";
        foreach (Match match in Regex.Matches(line, pattern, RegexOptions.None))
        {
            var groups = match.Groups;
            var product = Int32.Parse(groups[1].Value) * Int32.Parse(groups[2].Value);
            sum += product; 
        }

        return sum;
    }


    // Answer: 178538786
    public long Solve(string filepath)
    {
        StreamReader reader = new StreamReader(filepath);
        long result = 0;

        string? line = reader.ReadLine();
        // string pattern = @"mul\(\b\d{1,3}\b,\b\d{1,3}\b\)";
        while (!string.IsNullOrEmpty(line))
        {
            result += MultiplyAndSumGroups(line);
            line = reader.ReadLine();
        }
        return result;
    }

}