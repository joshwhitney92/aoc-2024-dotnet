
using aoc_2024_dotnet.Library.Solutions.Day2;

namespace aoc_2024_dotnet.Tests.Solution2;

[TestClass]
public sealed class Solution2Tests
{
    [TestMethod]
    public void Solution_Is_Decreasing_Works()
    {
        // Arrange
        var list = new List<int> { 7, 6, 4, 2, 1 };
        var sut = new Solution();

        // Act
        var result = sut.IsDecreasing(list);

        // Assert
        Assert.IsTrue(result);
    }



    [TestMethod]
    public void Solution_HasDuplicates_Fails()
    {
        // Arrange
        var list = new List<int> { 7, 6, 6, 2, 1 };
        var sut = new Solution();

        // Act
        var result = sut.IsSafe(list);

        // Assert
        Assert.IsFalse(result);
    }



    [TestMethod]
    public void Solution_Sequence_Out_of_Order_Fails()
    {
        // Arrange
        var list = new List<int> { 1, 3, 2, 4, 5 };
        var sut = new Solution();

        // Act
        var result = sut.IsSafe(list);

        // Assert
        Assert.IsFalse(result);
    }



    [TestMethod]
    public void Solution_Has_Difference_Out_Of_Range_Fails()
    {
        // Arrange
        var list = new List<int> { 7, 6, 6, 99, 1 };
        var sut = new Solution();

        // Act
        var result = sut.IsSafe(list);

        // Assert
        Assert.IsFalse(result);
    }


    [TestMethod]
    public void Solution_Is_Increasing_Works()
    {
        // Arrange
        var list = new List<int> { 1, 3, 6, 7, 9 };
        var sut = new Solution();

        // Act
        var result = sut.IsIncreasing(list);

        // Assert
        Assert.IsTrue(result);
    }



    [TestMethod]
    public void Solution_IsSafe_Works()
    {
        // Arrange
        var list = new List<int> { 1, 3, 6, 7, 9 };
        var sut = new Solution();

        // Act
        var result = sut.IsSafe(list);

        // Assert
        Assert.IsTrue(result);
    }



    [TestMethod]
    public void Solution_IsSafeAlt_Works()
    {
        // Arrange
        var list = new List<int> { 1, 3, 6, 7, 9 };
        var sut = new Solution();

        // Act
        var result = sut.IsSafeAlt(list);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Solution_IsSafe_Fails_For_Unsafe_Report()
    {
        // Arrange
        // var list = new List<int> {1, 2, 7, 8, 9};


        // This should return false 
        var list = new List<int> { 4, 6, 8, 10, 11, 14, 19 };

        var sut = new Solution();

        // Act
        var result = sut.IsSafe(list);

        // Assert
        Assert.IsFalse(result);
    }


    [TestMethod]
    public void Solution_IsSafeWithDampener_Works()
    {
        // Arrange
        // var list = new List<int> {1, 2, 7, 8, 9};


        // This should return true. Can remove level 3 to make it safe.
        // var list = new List<int> {1, 3, 2, 4, 5};
        // var list = new List<int> { 3, 5, 6, 8, 13, 18 };
        var list = new List<int> { 37, 35, 36, 37, 34 };





        var sut = new Solution();

        // Act
        var result = sut.IsSafeWithDampener(list);

        // Assert
        Assert.IsFalse(result);
    }






    [TestMethod]
    public void IsWithinBounds_Works()
    {
        // Arrange
        var sut = new Solution();

        // Act
        var result = sut.IsWithinBounds(1, 2);

        // Assert
        Assert.IsFalse(sut.IsWithinBounds(1, 1), "Difference of 0 should not work.");
        Assert.IsTrue(sut.IsWithinBounds(1, 2), "Difference of 1 should work.");
        Assert.IsTrue(sut.IsWithinBounds(1, 3), "Difference of 2 should work.");
        Assert.IsTrue(sut.IsWithinBounds(1, 4), "Difference of 3 should work.");
        Assert.IsFalse(sut.IsWithinBounds(1, 5), "Difference of 4 should not work.");
        Assert.IsFalse(sut.IsWithinBounds(14, 19), "Difference of 5 should not work.");
        Assert.IsTrue(result);
    }




}
