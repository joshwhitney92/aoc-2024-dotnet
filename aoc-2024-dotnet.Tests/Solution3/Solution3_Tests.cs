

using aoc_2024_dotnet.Library.Solutions.Day3;

namespace aoc_2024_dotnet.Tests.Solution3;

[TestClass]
public sealed class Solution3Tests
{

    [TestMethod]
    public void Solve2_Works()
    {
        // Arrange
        List<string> lines = new List<string> { @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))" };
        var sut = new Solution();

        // Act
        var result = sut.Solve2(lines);

        // Assert
        Assert.IsTrue(result == 48, $"result was {result}");
    }
}
