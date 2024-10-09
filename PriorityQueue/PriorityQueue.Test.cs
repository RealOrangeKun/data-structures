using Xunit;

namespace PriorityQueue
{
    public class PriorityQueueTests
    {
        [Fact]
        public void Enqueue_AddsElementsToPriorityQueue()
        {
            // Arrange
            var priorityQueue = new PriorityQueue<int>(Priority.Maximum);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(1);

            // Act
            var result = priorityQueue.Dequeue();

            // Assert
            Assert.Equal(10, result); // Maximum priority should come out first
        }

        [Fact]
        public void Dequeue_RemovesHighestPriorityElement()
        {
            // Arrange
            var priorityQueue = new PriorityQueue<int>(Priority.Minimum);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(1);

            // Act
            var result = priorityQueue.Dequeue();

            // Assert
            Assert.Equal(1, result); // Minimum priority should come out first
        }

        [Fact]
        public void IsEmpty_ReturnsTrueWhenQueueIsEmpty()
        {
            // Arrange
            var priorityQueue = new PriorityQueue<int>(Priority.Maximum);

            // Act
            var result = priorityQueue.IsEmpty();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Peek_ReturnsHighestPriorityElementWithoutRemovingIt()
        {
            // Arrange
            var priorityQueue = new PriorityQueue<int>(Priority.Maximum);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(1);

            // Act
            var result = priorityQueue.Peek();

            // Assert
            Assert.Equal(10, result); // Peek should return the highest priority without removal
            Assert.False(priorityQueue.IsEmpty()); // The queue should not be empty
        }

        [Fact]
        public void Clear_RemovesAllElements()
        {
            // Arrange
            var priorityQueue = new PriorityQueue<int>(Priority.Maximum);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(1);

            // Act
            priorityQueue.Clear();

            // Assert
            Assert.True(priorityQueue.IsEmpty());
        }
    }
}
