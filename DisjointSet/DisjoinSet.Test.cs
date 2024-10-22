using Xunit;

namespace DisjointSet;
public class DisjointSetTests
{
    [Fact]
    public void MakeSet_ShouldCreateNewSet()
    {
        var ds = new DisjointSet<string>();

        ds.MakeSet("A");

        Assert.Equal("A", ds.Find("A"));
    }

    [Fact]
    public void MakeSet_ShouldThrowException_WhenSetAlreadyExists()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");

        Assert.Throws<ArgumentException>(() => ds.MakeSet("A"));
    }

    [Fact]
    public void Find_ShouldReturnRepresentative()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");

        Assert.Equal("A", ds.Find("A"));
    }

    [Fact]
    public void Find_ShouldThrowException_WhenItemDoesNotExist()
    {
        var ds = new DisjointSet<string>();

        Assert.Throws<ArgumentException>(() => ds.Find("NonExistent"));
    }

    [Fact]
    public void Union_ShouldMergeTwoSets()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");
        ds.MakeSet("B");

        ds.Union("A", "B");

        Assert.Equal(ds.Find("A"), ds.Find("B"));
    }

    [Fact]
    public void Union_ShouldMergeSmallerSetIntoLarger()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");
        ds.MakeSet("B");
        ds.MakeSet("C");

        ds.Union("A", "B");  // Union of A and B.
        ds.Union("B", "C");  // Union of (A, B) with C.

        Assert.Equal(ds.Find("A"), ds.Find("C"));
    }

    [Fact]
    public void Union_ShouldNotMergeAlreadyConnectedSets()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");
        ds.MakeSet("B");

        ds.Union("A", "B");
        var representative = ds.Find("A");

        ds.Union("A", "B");  // Should have no effect.

        Assert.Equal(representative, ds.Find("A"));
        Assert.Equal(representative, ds.Find("B"));
    }

    [Fact]
    public void Find_ShouldUsePathCompression()
    {
        var ds = new DisjointSet<string>();
        ds.MakeSet("A");
        ds.MakeSet("B");
        ds.MakeSet("C");

        ds.Union("A", "B");
        ds.Union("B", "C");

        var root = ds.Find("A");

        // Check if path compression worked (all should have the same representative).
        Assert.Equal(root, ds.Find("B"));
        Assert.Equal(root, ds.Find("C"));
    }
}
