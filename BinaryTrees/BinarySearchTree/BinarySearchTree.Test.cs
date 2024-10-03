using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTrees.BinarySearchTree
{
    public class BinarySearchTreeTests
    {
        private readonly BinarySearchTree<int> _bst = new();

        [Fact]
        public void Insert_ShouldAddSingleValue()
        {
            _bst.Insert(10);
            Assert.True(_bst.Contains(10));
        }

        [Fact]
        public void Insert_ShouldNotAddDuplicateValues()
        {
            _bst.Insert(10);
            _bst.Insert(10);
            Assert.Equal(1, CountNodes(_bst));
        }

        [Fact]
        public void Contains_ShouldReturnFalseForEmptyTree()
        {
            Assert.False(_bst.Contains(10));
        }

        [Fact]
        public void Contains_ShouldReturnTrueForExistingValue()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            Assert.True(_bst.Contains(5));
        }

        [Fact]
        public void Remove_ShouldRemoveLeafNode()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Remove(5);
            Assert.False(_bst.Contains(5));
        }

        [Fact]
        public void Remove_ShouldRemoveNodeWithOneChild()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            _bst.Remove(10);
            Assert.False(_bst.Contains(10));
            Assert.True(_bst.Contains(5));
            Assert.True(_bst.Contains(15));
        }

        [Fact]
        public void Remove_ShouldRemoveNodeWithTwoChildren()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            _bst.Insert(7);
            _bst.Remove(5);
            Assert.False(_bst.Contains(5));
            Assert.True(_bst.Contains(7));
        }

        [Fact]
        public void Remove_ShouldNotThrowForNonExistentValue()
        {
            _bst.Insert(10);
            _bst.Remove(20);
            Assert.True(_bst.Contains(10));
        }

        [Fact]
        public void TraverseInOrder_ShouldReturnValuesInOrder()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            var result = _bst.TraverseInOrder();
            var expected = new List<int> { 5, 10, 15 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TraversePreOrder_ShouldReturnValuesInPreOrder()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            var result = _bst.TraversePreOrder();
            var expected = new List<int> { 10, 5, 15 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TraversePostOrder_ShouldReturnValuesInPostOrder()
        {
            _bst.Insert(10);
            _bst.Insert(5);
            _bst.Insert(15);
            var result = _bst.TraversePostOrder();
            var expected = new List<int> { 5, 15, 10 };
            Assert.Equal(expected, result);
        }

        private static int CountNodes(BinarySearchTree<int> bst)
        {
            int count = 0;
            foreach (var _ in bst)
            {
                count++;
            }
            return count;
        }
    }
}
