using System.Collections;

namespace BinaryTrees.BinarySearchTree
{
    public class BinarySearchTree<T> : IBinaryTree<T>, IEnumerable<T> where T : IComparable<T>
    {
        private TreeNode<T>? _root;
        public bool Contains(T value)
        {
            if (_root is null) return false;

            TreeNode<T>? current = _root;
            while (current is not null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root is null) yield break;
            Queue<TreeNode<T>> queue = new();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                if (node.Left is not null) queue.Enqueue(node.Left);
                if (node.Right is not null) queue.Enqueue(node.Right);
            }
        }

        public void Insert(T value)
        {
            if (_root is null)
            {
                _root = new TreeNode<T>() { Value = value };
                return;
            }

            TreeNode<T>? current = _root;
            TreeNode<T>? parent = null;
            while (current is not null)
            {
                parent = current;
                if (value.Equals(current.Value)) return;
                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (value.CompareTo(parent!.Value) < 0)
            {
                parent.Left = new TreeNode<T>() { Value = value };
            }
            else
            {
                parent.Right = new TreeNode<T>() { Value = value };
            }
        }

        public void Remove(T value)
        {
            if (_root is null) return;
            _root = BinarySearchTree<T>.RemoveRecursive(_root, value);
        }

        private static TreeNode<T>? RemoveRecursive(TreeNode<T>? node, T value)
        {
            if (node is null) return node;
            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = BinarySearchTree<T>.RemoveRecursive(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = BinarySearchTree<T>.RemoveRecursive(node.Right, value);
            }
            else
            {
                if (node.Left is null && node.Right is null)
                {
                    node = null;
                }
                else if (node.Left is null)
                {
                    return node.Right;
                }
                else if (node.Right is null)
                {
                    return node.Left;
                }
                else
                {
                    TreeNode<T> min = BinarySearchTree<T>.FindMin(node.Right);
                    node.Value = min.Value;
                    node.Right = BinarySearchTree<T>.RemoveRecursive(node.Right, min.Value);
                }
            }
            return node;
        }
        private static TreeNode<T> FindMin(TreeNode<T> node)
        {
            if (node.Left is null) return node;
            return BinarySearchTree<T>.FindMin(node.Left);
        }
        public IEnumerable<T> TraverseInOrder()
        {
            if (_root is null) yield break;

            foreach (var item in BinarySearchTree<T>.InorderRec(_root))
            {
                yield return item;
            }

        }
        private static IEnumerable<T> InorderRec(TreeNode<T> node)
        {
            if (node.Left is not null)
            {
                foreach (var left in InorderRec(node.Left))
                {
                    yield return left;
                }
            }

            yield return node.Value;

            if (node.Right is not null)
            {
                foreach (var right in InorderRec(node.Right))
                {
                    yield return right;
                }
            }
        }

        public IEnumerable<T> TraversePostOrder()
        {
            if (_root is null) yield break;

            foreach (var item in BinarySearchTree<T>.PostorderRec(_root))
            {
                yield return item;
            }
        }
        private static IEnumerable<T> PostorderRec(TreeNode<T> node)
        {
            if (node.Left is not null)
            {
                foreach (var left in PostorderRec(node.Left))
                {
                    yield return left;
                }
            }

            if (node.Right is not null)
            {
                foreach (var right in PostorderRec(node.Right))
                {
                    yield return right;
                }
            }
            yield return node.Value;
        }

        public IEnumerable<T> TraversePreOrder()
        {
            if (_root is null) yield break;
            foreach (var item in BinarySearchTree<T>.PreorderRec(_root))
            {
                yield return item;
            }
        }
        private static IEnumerable<T> PreorderRec(TreeNode<T> node)
        {
            yield return node.Value;

            if (node.Left is not null)
            {
                foreach (var left in PreorderRec(node.Left))
                {
                    yield return left;
                }
            }

            if (node.Right is not null)
            {
                foreach (var right in PreorderRec(node.Right))
                {
                    yield return right;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();
        }
    }
}