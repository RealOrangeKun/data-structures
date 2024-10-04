using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees.AVLTree.Tests
{
    public class AVLTreeTests
    {
        [Fact]
        public void Insert_SingleElement_ShouldContainElement()
        {
            // Arrange
            var tree = new AVLTree<int>();

            // Act
            tree.Insert(10);

            // Assert
            Assert.True(tree.Contains(10));
        }

        [Fact]
        public void Insert_MultipleElements_ShouldContainAllElements()
        {
            // Arrange
            var tree = new AVLTree<int>();
            var elements = new List<int> { 10, 20, 5, 6, 15 };

            // Act
            foreach (var elem in elements)
            {
                tree.Insert(elem);
            }

            // Assert
            foreach (var elem in elements)
            {
                Assert.True(tree.Contains(elem));
            }
        }

        [Fact]
        public void Insert_DuplicateElement_ShouldNotAddIt()
        {
            // Arrange
            var tree = new AVLTree<int>();

            // Act
            tree.Insert(10);
            tree.Insert(10);

            // Assert
            var inOrderTraversal = tree.TraverseInOrder().ToList();
            Assert.Single(inOrderTraversal, 10);
        }

        [Fact]
        public void Remove_ElementExists_ShouldRemoveAndBalance()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            // Act
            tree.Remove(10);

            // Assert
            Assert.False(tree.Contains(10));
            Assert.True(tree.Contains(20));
            Assert.True(tree.Contains(5));
        }

        [Fact]
        public void Remove_Root_ShouldRebalanceTree()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            // Act
            tree.Remove(10);

            // Assert
            Assert.False(tree.Contains(10));
            var inOrderTraversal = tree.TraverseInOrder().ToList();
            Assert.Equal(new List<int> { 5, 20 }, inOrderTraversal);
        }

        [Fact]
        public void Remove_ElementDoesNotExist_ShouldDoNothing()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);
            tree.Insert(20);

            // Act
            tree.Remove(30);

            // Assert
            Assert.True(tree.Contains(10));
            Assert.True(tree.Contains(20));
        }

        [Fact]
        public void Insert_MultipleElements_ShouldBeBalanced()
        {
            // Arrange
            var tree = new AVLTree<int>();

            // Act
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);

            // Assert
            var balanceFactor = AVLTree<int>.GetBalanceFactor(tree._root);
            Assert.InRange(balanceFactor, -1, 1);  // Ensure the tree is balanced
        }

        [Fact]
        public void TraverseInOrder_ShouldReturnSortedElements()
        {
            // Arrange
            var tree = new AVLTree<int>();
            var elements = new List<int> { 10, 20, 5, 6, 15 };

            // Act
            foreach (var elem in elements)
            {
                tree.Insert(elem);
            }

            var result = tree.TraverseInOrder().ToList();

            // Assert
            var expected = elements.OrderBy(e => e).ToList();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TraversePreOrder_ShouldReturnCorrectOrder()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);

            // Act
            var result = tree.TraversePreOrder().ToList();

            // Assert
            var expected = new List<int> { 10, 5, 20 };  // Pre-order should visit root, left, right
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TraversePostOrder_ShouldReturnCorrectOrder()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);

            // Act
            var result = tree.TraversePostOrder().ToList();

            // Assert
            var expected = new List<int> { 5, 20, 10 };  // Post-order should visit left, right, root
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Remove_OnlyElement_ShouldReturnEmptyTree()
        {
            // Arrange
            var tree = new AVLTree<int>();
            tree.Insert(10);

            // Act
            tree.Remove(10);

            // Assert
            Assert.False(tree.Contains(10));
            Assert.Empty(tree.TraverseInOrder());
        }
    }
}
