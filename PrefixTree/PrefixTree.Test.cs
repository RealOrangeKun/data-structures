using Xunit;

namespace PrefixTree;
public class PrefixTreeTests
{
    private readonly PrefixTree _prefixTree;

    public PrefixTreeTests()
    {
        _prefixTree = new PrefixTree();
    }

    [Fact]
    public void Insert_And_Search_Word_ReturnsTrue()
    {
        _prefixTree.Insert("apple");
        Assert.True(_prefixTree.Search("apple"));
    }

    [Fact]
    public void Insert_And_Search_UnknownWord_ReturnsFalse()
    {
        _prefixTree.Insert("apple");
        Assert.False(_prefixTree.Search("app"));
    }

    [Fact]
    public void StartsWith_ReturnsTrue_WhenPrefixExists()
    {
        _prefixTree.Insert("apple");
        Assert.True(_prefixTree.StartsWith("app"));
    }

    [Fact]
    public void StartsWith_ReturnsFalse_WhenPrefixDoesNotExist()
    {
        _prefixTree.Insert("apple");
        Assert.False(_prefixTree.StartsWith("banana"));
    }

    [Fact]
    public void Delete_Word_ThatExists_ReturnsTrue()
    {
        _prefixTree.Insert("apple");
        Assert.True(_prefixTree.Delete("apple"));
        Assert.False(_prefixTree.Search("apple"));
    }

    [Fact]
    public void Delete_Word_ThatDoesNotExist_ReturnsFalse()
    {
        _prefixTree.Insert("apple");
        Assert.False(_prefixTree.Delete("banana"));
    }

    [Fact]
    public void Delete_PartialWord_DoesNotAffectOtherWords()
    {
        _prefixTree.Insert("apple");
        _prefixTree.Insert("app");
        Assert.True(_prefixTree.Delete("app"));
        Assert.True(_prefixTree.Search("apple"));
        Assert.False(_prefixTree.Search("app"));
    }

    [Fact]
    public void Delete_Word_ThatIsPrefixOfAnother_ReturnsCorrectly()
    {
        _prefixTree.Insert("app");
        _prefixTree.Insert("apple");
        Assert.True(_prefixTree.Delete("app"));
        Assert.False(_prefixTree.Search("app"));
        Assert.True(_prefixTree.Search("apple"));
    }
}
