using Xunit;

namespace Queue;

public class QueueTests
{
    [Fact]
    public void Enqueue_IncreasesCount()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Assert
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Dequeue_ReturnsFirstElement()
    {
        // Arrange
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        var result = queue.Dequeue();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Dequeue_RemovesFirstElement()
    {
        // Arrange
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        queue.Dequeue();

        // Assert
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Peek_ReturnsFirstElementWithoutRemoving()
    {
        // Arrange
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        var result = queue.Peek();

        // Assert
        Assert.Equal(1, result);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Clear_ResetsQueue()
    {
        // Arrange
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        queue.Clear();

        // Assert
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Peek_ReturnsDefaultIfEmpty()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        var result = queue.Peek();

        // Assert
        Assert.Equal(default(int), result);
    }

    [Fact]
    public void Dequeue_ReturnsDefaultIfEmpty()
    {
        // Arrange
        var queue = new Queue<int>();

        // Act
        var result = queue.Dequeue();

        // Assert
        Assert.Equal(default(int), result);
    }
}
