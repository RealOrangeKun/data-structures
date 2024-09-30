using Xunit;

namespace SingleLinkedList;

public class SingleLinkedListTests
{
    [Fact]
    public void PushBack_AddsElementToEndOfList()
    {
        // Arrange
        var list = new SingleLinkedList<int>();

        // Act
        list.PushBack(1);
        list.PushBack(2);

        // Assert
        Assert.Equal(2, list.Length);
        Assert.Equal(1, list.GetFirst());
        Assert.Equal(2, list.GetLast());
    }

    [Fact]
    public void PushFront_AddsElementToFrontOfList()
    {
        // Arrange
        var list = new SingleLinkedList<int>();

        // Act
        list.PushFront(1);
        list.PushFront(2);

        // Assert
        Assert.Equal(2, list.Length);
        Assert.Equal(2, list.GetFirst());
        Assert.Equal(1, list.GetLast());
    }

    [Fact]
    public void Remove_RemovesSpecifiedElement()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);
        list.PushBack(3);

        // Act
        list.Remove(2);

        // Assert
        Assert.Equal(2, list.Length);
        Assert.False(list.Contains(2));
        Assert.True(list.Contains(1));
        Assert.True(list.Contains(3));
    }

    [Fact]
    public void RemoveFirst_RemovesFirstElement()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);
        list.PushBack(3);

        // Act
        list.RemoveFirst();

        // Assert
        Assert.Equal(2, list.Length);
        Assert.Equal(2, list.GetFirst());
    }

    [Fact]
    public void RemoveLast_RemovesLastElement()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);
        list.PushBack(3);

        // Act
        list.RemoveLast();

        // Assert
        Assert.Equal(2, list.Length);
        Assert.Equal(2, list.GetLast());
    }

    [Fact]
    public void RemoveAt_RemovesElementAtIndex()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);
        list.PushBack(3);

        // Act
        list.RemoveAt(1);

        // Assert
        Assert.Equal(2, list.Length);
        Assert.False(list.Contains(2));
    }

    [Fact]
    public void Contains_ReturnsTrueIfElementExists()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);

        // Act
        bool contains = list.Contains(2);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Contains_ReturnsFalseIfElementDoesNotExist()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);

        // Act
        bool contains = list.Contains(3);

        // Assert
        Assert.False(contains);
    }

    [Fact]
    public void GetFirst_ReturnsFirstElement()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);

        // Act
        int? first = list.GetFirst();

        // Assert
        Assert.Equal(1, first);
    }

    [Fact]
    public void GetLast_ReturnsLastElement()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);

        // Act
        int? last = list.GetLast();

        // Assert
        Assert.Equal(2, last);
    }

    [Fact]
    public void Clear_RemovesAllElements()
    {
        // Arrange
        var list = new SingleLinkedList<int>();
        list.PushBack(1);
        list.PushBack(2);

        // Act
        list.Clear();

        // Assert
        Assert.Equal(0, list.Length);
        Assert.False(list.Contains(1));
        Assert.False(list.Contains(2));
    }
}

