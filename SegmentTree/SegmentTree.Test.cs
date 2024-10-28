using Xunit;
using SegmentTree;

namespace SegmentTree;
public class SegmentTreeTests
{
    [Fact]
    public void Build_ShouldCorrectlyInitializeSegmentTree()
    {
        // Arrange
        int[] input = [1, 3, 5, 7, 9, 11];
        var segmentTree = new SegmentTree<int>(input);

        // Act
        int? result = segmentTree.Query(0, 5);

        // Assert
        Assert.Equal(36, result); // Sum of all elements (1+3+5+7+9+11)
    }

    [Fact]
    public void Query_ShouldReturnCorrectSum_ForGivenRange()
    {
        // Arrange
        int[] input = [1, 3, 5, 7, 9, 11];
        var segmentTree = new SegmentTree<int>(input);

        // Act
        int? result = segmentTree.Query(1, 3);

        // Assert
        Assert.Equal(15, result); // Sum of elements from index 1 to 3 (3+5+7)
    }

    [Fact]
    public void Update_ShouldCorrectlyUpdateValue_AndReflectInQueries()
    {
        // Arrange
        int[] input = [1, 3, 5, 7, 9, 11];
        var segmentTree = new SegmentTree<int>(input);

        // Act
        segmentTree.Update(1, 10); // Update index 1 to 10
        int? result = segmentTree.Query(1, 3);

        // Assert
        Assert.Equal(22, result); // Sum after update: (10+5+7)
    }

    [Fact]
    public void Query_ShouldReturnZero_ForNonOverlappingRange()
    {
        // Arrange
        int[] input = [1, 3, 5, 7, 9, 11];
        var segmentTree = new SegmentTree<int>(input);

        // Act
        int? result = segmentTree.Query(6, 8); // Query out of range

        // Assert
        Assert.Equal(0, result); // Should return default value for int, which is 0
    }

    [Fact]
    public void Update_ShouldReturnFalse_IfIndexOutOfRange()
    {
        // Arrange
        int[] input = [1, 3, 5, 7, 9, 11];
        var segmentTree = new SegmentTree<int>(input);

        // Act
        bool success = segmentTree.Update(10, 100); // Update index out of range

        // Assert
        Assert.False(success); // Should return false for out-of-range update
    }
}
