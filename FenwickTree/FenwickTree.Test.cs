using Xunit;

namespace FenwickTree;
public class FenwickTreeTests
{
    private readonly FenwickTree _fenwickTree;

    public FenwickTreeTests()
    {
        // Initialize with an example array (indexing starts at 1, so we use a dummy 0 at index 0)
        var values = new List<int> { 1, 2, 3, 4, 5 };
        _fenwickTree = new FenwickTree(values);
    }

    [Fact]
    public void Query_ShouldReturnCorrectCumulativeSum()
    {
        Assert.Equal(1, _fenwickTree.Query(1));   // Sum from index 1
        Assert.Equal(3, _fenwickTree.Query(2));   // Sum from index 1 to 2
        Assert.Equal(10, _fenwickTree.Query(4));  // Sum from index 1 to 4
        Assert.Equal(15, _fenwickTree.Query(5));  // Sum from index 1 to 5
    }

    [Fact]
    public void RangeQuery_ShouldReturnCorrectRangeSum()
    {
        Assert.Equal(3, _fenwickTree.RangeQuery(1, 2));    // Sum from index 1 to 2
        Assert.Equal(9, _fenwickTree.RangeQuery(2, 4));    // Sum from index 2 to 4
        Assert.Equal(12, _fenwickTree.RangeQuery(3, 5));   // Sum from index 3 to 5
    }

    [Fact]
    public void Update_ShouldCorrectlyAdjustValues()
    {
        _fenwickTree.Update(3, 2);  // Increment index 3 by 2
        Assert.Equal(17, _fenwickTree.Query(5));  // Verify new cumulative sum
        Assert.Equal(8, _fenwickTree.Query(3));   // Sum from index 1 to 3 should now reflect the update

        _fenwickTree.Update(1, -1); // Decrement index 1 by 1
        Assert.Equal(16, _fenwickTree.Query(5));  // Verify cumulative sum reflects this update
        Assert.Equal(7, _fenwickTree.Query(3));   // Sum from index 1 to 3 should reflect both updates
    }
}

