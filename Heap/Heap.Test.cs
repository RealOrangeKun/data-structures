using Xunit;

namespace Heap
{
    public class HeapTests
    {
        [Fact]
        public void Insert_ShouldIncreaseCount()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(5);
            heap.Insert(3);
            Assert.Equal(2, heap.Count);
        }

        [Fact]
        public void Peek_ShouldReturnRootWithoutRemoving()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(5);
            heap.Insert(3);
            Assert.Equal(3, heap.Peek());
            Assert.Equal(2, heap.Count);
        }

        [Fact]
        public void Remove_ShouldReturnAndRemoveRoot()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(5);
            heap.Insert(3);
            int removed = heap.Remove();
            Assert.Equal(3, removed);
            Assert.Equal(1, heap.Count);
        }

        [Fact]
        public void Remove_ShouldThrowExceptionWhenEmpty()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            Assert.Throws<InvalidOperationException>(() => heap.Remove());
        }

        [Fact]
        public void Peek_ShouldThrowExceptionWhenEmpty()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }

        [Fact]
        public void Insert_ShouldMaintainHeapProperty()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(5);
            heap.Insert(3);
            heap.Insert(4);
            Assert.Equal(3, heap.Remove()); // 3 is the root
            Assert.Equal(4, heap.Remove()); // 4 is the next
            Assert.Equal(5, heap.Remove()); // 5 is the last
        }

        [Fact]
        public void Clear_ShouldResetHeap()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(1);
            heap.Insert(2);
            heap.Clear();
            Assert.Equal(0, heap.Count);
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }

        [Fact]
        public void Resize_ShouldAllowMoreInserts()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            for (int i = 0; i < 20; i++)
            {
                heap.Insert(i);
            }
            Assert.Equal(20, heap.Count);
            Assert.Equal(0, heap.Remove());
        }

        [Fact]
        public void MinHeap_ShouldMaintainCorrectOrder()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(5);
            heap.Insert(15);
            Assert.Equal(5, heap.Remove());
            Assert.Equal(10, heap.Remove());
            Assert.Equal(15, heap.Remove());
            Assert.Equal(20, heap.Remove());
        }

        [Fact]
        public void MaxHeap_ShouldMaintainCorrectOrder()
        {
            var heap = new Heap<int>(HeapType.MaxHeap);
            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(5);
            heap.Insert(15);
            Assert.Equal(20, heap.Remove());
            Assert.Equal(15, heap.Remove());
            Assert.Equal(10, heap.Remove());
            Assert.Equal(5, heap.Remove());
        }

        [Fact]
        public void Insert_NegativeNumbers_ShouldMaintainHeapProperty()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(-5);
            heap.Insert(-1);
            heap.Insert(-10);
            Assert.Equal(-10, heap.Remove());
            Assert.Equal(-5, heap.Remove());
            Assert.Equal(-1, heap.Remove());
        }

        [Fact]
        public void Insert_EqualElements_ShouldMaintainHeapProperty()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(1);
            heap.Insert(1);
            heap.Insert(1);
            Assert.Equal(1, heap.Remove());
            Assert.Equal(1, heap.Remove());
            Assert.Equal(1, heap.Remove());
        }

        [Fact]
        public void RemoveAt_ValidIndex_RemovesElementAndMaintainsHeap()
        {
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(1);
            heap.Insert(4);

            // Arrange
            int indexToRemove = 1; // Assuming that 5 is at index 1

            // Act
            int removedItem = heap.RemoveAt(indexToRemove);

            // Assert
            Assert.Equal(4, removedItem); // Verify the removed item
        }

        [Fact]
        public void RemoveAt_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(1);
            heap.Insert(4);

            int invalidIndex = 10; // Out of bounds index

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => heap.RemoveAt(invalidIndex));
        }

        [Fact]
        public void RemoveAt_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var heap = new Heap<int>(HeapType.MinHeap);
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(1);
            heap.Insert(4);

            int negativeIndex = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => heap.RemoveAt(negativeIndex));
        }
    }
}
