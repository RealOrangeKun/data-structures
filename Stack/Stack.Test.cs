using Xunit;

namespace Stack;

public class StackTests
{
    [Fact]
    public void Push_ShouldAddElementToStack()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.Count); // Should have 3 elements
    }

    [Fact]
    public void Pop_ShouldRemoveAndReturnElementFromStack()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Equal(3, result); // Should return the top element (3)
        Assert.Equal(2, stack.Count); // Should now have 2 elements
    }

    [Fact]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Equal(3, result); // Should return the top element (3)
        Assert.Equal(3, stack.Count); // Count should still be 3
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueIfStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act & Assert
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalseIfStackIsNotEmpty()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);

        // Act & Assert
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Clear_ShouldEmptyTheStack()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);

        // Act
        stack.Clear();

        // Assert
        Assert.Equal(0, stack.Count); // Stack should be empty
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Pop_ShouldReturnDefault_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Equal(0, result); // Should return default value for int (0)
    }

    [Fact]
    public void Peek_ShouldReturnDefault_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Equal(0, result); // Should return default value for int (0)
    }

    [Fact]
    public void Pop_ShouldReturnNull_ForReferenceType_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<string>();

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Null(result); // Should return null for reference types
    }

    [Fact]
    public void Peek_ShouldReturnNull_ForReferenceType_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<string>();

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Null(result); // Should return null for reference types
    }
}

