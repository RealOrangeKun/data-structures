using System.Linq;
using Xunit;

namespace LinkedLists.DoublyLinkedList
{
    public class DoubleLinkedListTests
    {
        [Fact]
        public void PushBack_ShouldAddElementsToEndOfList()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            // Assert
            Assert.Equal(3, list.Length);
            Assert.Equal(1, list.GetFirst());
            Assert.Equal(3, list.GetLast());
        }

        [Fact]
        public void PushFront_ShouldAddElementsToFrontOfList()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.PushFront(1);
            list.PushFront(2);
            list.PushFront(3);

            // Assert
            Assert.Equal(3, list.Length);
            Assert.Equal(3, list.GetFirst());
            Assert.Equal(1, list.GetLast());
        }

        [Fact]
        public void Remove_ShouldRemoveElementFromList()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            // Act
            list.Remove(2);

            // Assert
            Assert.Equal(2, list.Length);
            Assert.False(list.Contains(2));
            Assert.Equal(1, list.GetFirst());
            Assert.Equal(3, list.GetLast());
        }

        [Fact]
        public void RemoveFirst_ShouldRemoveFirstElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
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
        public void RemoveLast_ShouldRemoveLastElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
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
        public void RemoveAt_ShouldRemoveElementAtIndex()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            // Act
            list.RemoveAt(1); // Removes element at index 1

            // Assert
            Assert.Equal(2, list.Length);
            Assert.Equal(1, list.GetFirst());
            Assert.Equal(3, list.GetLast());
            Assert.False(list.Contains(2));
        }

        [Fact]
        public void Clear_ShouldEmptyTheList()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            // Act
            list.Clear();

            // Assert
            Assert.Equal(0, list.Length);
            Assert.False(list.Contains(1));
            Assert.False(list.Contains(2));
            Assert.False(list.Contains(3));
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfElementExists()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);

            // Act & Assert
            Assert.True(list.Contains(2));
            Assert.False(list.Contains(4));
        }
    }
}
