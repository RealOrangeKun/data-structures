using Xunit;
using PriorityQueue;

namespace IndexedPriorityQueue
{
    public class IndexedPriorityQueueTests
    {
        private readonly IndexedPriorityQueue<int> _minQueue;
        private readonly IndexedPriorityQueue<int> _maxQueue;

        public IndexedPriorityQueueTests()
        {
            _minQueue = new IndexedPriorityQueue<int>(Priority.Minimum);
            _maxQueue = new IndexedPriorityQueue<int>(Priority.Maximum);
        }

        [Fact]
        public void Enqueue_AddSingleElement_MinQueue()
        {
            _minQueue.Enqueue(5, 5);
            Assert.Equal(5, _minQueue.Peek());
        }

        [Fact]
        public void Enqueue_AddSingleElement_MaxQueue()
        {
            _maxQueue.Enqueue(3, 3);
            Assert.Equal(3, _maxQueue.Peek());
        }

        [Fact]
        public void Enqueue_AddMultipleElements_MinQueue()
        {
            _minQueue.Enqueue(3, 3);
            _minQueue.Enqueue(1, 1);
            _minQueue.Enqueue(2, 2);

            Assert.Equal(1, _minQueue.Dequeue());
            Assert.Equal(2, _minQueue.Dequeue());
            Assert.Equal(3, _minQueue.Dequeue());
        }

        [Fact]
        public void Enqueue_AddMultipleElements_MaxQueue()
        {
            _maxQueue.Enqueue(1, 1);
            _maxQueue.Enqueue(3, 3);
            _maxQueue.Enqueue(2, 2);

            Assert.Equal(3, _maxQueue.Dequeue());
            Assert.Equal(2, _maxQueue.Dequeue());
            Assert.Equal(1, _maxQueue.Dequeue());
        }

        [Fact]
        public void Dequeue_FromEmptyQueue()
        {
            Assert.Equal(0, _minQueue.Dequeue());
            Assert.Equal(0, _maxQueue.Dequeue());
        }

        [Fact]
        public void DecreaseKey_MinHeap()
        {
            _minQueue.Clear();
            _minQueue.Enqueue(3, 3);
            _minQueue.Enqueue(5, 5);
            _minQueue.DecreaseKey(5, 2);

            Assert.Equal(5, _minQueue.Peek());
            Assert.Equal(5, _minQueue.Dequeue());
            Assert.Equal(3, _minQueue.Dequeue());
        }

        [Fact]
        public void DecreaseKey_MaxHeap()
        {
            _maxQueue.Enqueue(1, 1);
            _maxQueue.Enqueue(3, 3);
            _maxQueue.DecreaseKey(1, 4); // No change as 4 is greater

            Assert.Equal(3, _maxQueue.Peek());
            _maxQueue.DecreaseKey(3, 2); // Decrease to 2

            Assert.Equal(3, _maxQueue.Dequeue());
            Assert.Equal(1, _maxQueue.Dequeue());
        }

        [Fact]
        public void Contains_ElementExists()
        {
            _minQueue.Enqueue(4, 4);
            Assert.True(_minQueue.Contains(4));
        }

        [Fact]
        public void Contains_ElementDoesNotExist()
        {
            Assert.False(_minQueue.Contains(99));
        }

        [Fact]
        public void Clear_EmptiesQueue()
        {
            _minQueue.Enqueue(1, 1);
            _minQueue.Clear();
            Assert.True(_minQueue.IsEmpty());
        }

        [Fact]
        public void Dequeue_RemovesElementsInOrder_MinHeap()
        {
            _minQueue.Enqueue(10, 10);
            _minQueue.Enqueue(20, 20);
            _minQueue.Enqueue(5, 5);

            Assert.Equal(5, _minQueue.Dequeue());
            Assert.Equal(10, _minQueue.Dequeue());
            Assert.Equal(20, _minQueue.Dequeue());
        }

        [Fact]
        public void Dequeue_RemovesElementsInOrder_MaxHeap()
        {
            _maxQueue.Enqueue(10, 10);
            _maxQueue.Enqueue(20, 20);
            _maxQueue.Enqueue(5, 5);

            Assert.Equal(20, _maxQueue.Dequeue());
            Assert.Equal(10, _maxQueue.Dequeue());
            Assert.Equal(5, _maxQueue.Dequeue());
        }
    }
}
