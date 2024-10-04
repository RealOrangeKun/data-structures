namespace BinaryTrees.AVLTree
{
    public class AVLTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        internal TreeNode<T>? _root;

        private static int GetHeight(TreeNode<T>? node)
        {
            if (node is null) return -1;
            return Math.Max(AVLTree<T>.GetHeight(node.Left), AVLTree<T>.GetHeight(node.Right)) + 1;
        }

        internal static int GetBalanceFactor(TreeNode<T>? node)
        {
            if (node is null) return 0;
            return AVLTree<T>.GetHeight(node.Left) - AVLTree<T>.GetHeight(node.Right);
        }
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

        public void Insert(T value)
        {
            _root ??= new TreeNode<T>() { Value = value };
            _root = AVLTree<T>.Insert(_root, value);
        }
        private static TreeNode<T>? Insert(TreeNode<T>? node, T value)
        {
            if (node is null) return new TreeNode<T>() { Value = value };

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = AVLTree<T>.Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = AVLTree<T>.Insert(node.Right, value);
            }
            else
            {
                return node;
            }
            int balanceFactor = AVLTree<T>.GetBalanceFactor(node);
            // LL
            if (balanceFactor > 1 && value.CompareTo(node.Left!.Value) < 0)
            {
                return AVLTree<T>.RotateRight(node);
            }
            // RR
            if (balanceFactor < -1 && value.CompareTo(node.Right!.Value) > 0)
            {
                return AVLTree<T>.RotateLeft(node);
            }
            // LR
            if (balanceFactor > 1 && value.CompareTo(node.Left!.Value) > 0)
            {
                node.Left = AVLTree<T>.RotateLeft(node.Left);
                return AVLTree<T>.RotateRight(node);
            }
            // RL  
            if (balanceFactor < -1 && value.CompareTo(node.Right!.Value) < 0)
            {
                node.Right = AVLTree<T>.RotateRight(node.Right);
                return AVLTree<T>.RotateLeft(node);
            }
            return node;
        }
        private static TreeNode<T> RotateLeft(TreeNode<T> node)
        {
            TreeNode<T> newRoot = node.Right!;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            return newRoot;
        }
        private static TreeNode<T> RotateRight(TreeNode<T> node)
        {
            TreeNode<T> newRoot = node.Left!;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            return newRoot;
        }

        public void Remove(T value)
        {
            if (_root is null) return;
            _root = AVLTree<T>.Remove(_root, value);

        }
        private static TreeNode<T>? Remove(TreeNode<T>? node, T value)
        {
            if (node is null) return null;

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = AVLTree<T>.Remove(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = AVLTree<T>.Remove(node.Right, value);
            }
            else
            {
                if (node.Left is null)
                {
                    return node.Right;
                }
                else if (node.Right is null)
                {
                    return node.Left;
                }
                node.Value = FindMin(node.Right).Value;
                node.Right = AVLTree<T>.Remove(node.Right, node.Value);
            }

            int balanceFactor = AVLTree<T>.GetBalanceFactor(node);
            // LL
            if (balanceFactor > 1 && AVLTree<T>.GetBalanceFactor(node.Left) >= 0)
            {
                return AVLTree<T>.RotateRight(node);
            }
            // RR
            if (balanceFactor < -1 && AVLTree<T>.GetBalanceFactor(node.Right) <= 0)
            {
                return AVLTree<T>.RotateLeft(node);
            }
            // LR
            if (balanceFactor > 1 && AVLTree<T>.GetBalanceFactor(node.Left) < 0)
            {
                node.Left = AVLTree<T>.RotateLeft(node.Left);
                return AVLTree<T>.RotateRight(node);
            }
            // RL
            if (balanceFactor < -1 && AVLTree<T>.GetBalanceFactor(node.Right) > 0)
            {
                node.Right = AVLTree<T>.RotateRight(node.Right);
                return AVLTree<T>.RotateLeft(node);
            }

            return node;
        }
        private static TreeNode<T> FindMin(TreeNode<T> node)
        {
            if (node.Left is null) return node;
            return FindMin(node.Left);
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root is null) yield break;
            foreach (var item in TraverseInOrder(_root))
            {
                yield return item;
            }
        }
        private static IEnumerable<T> TraverseInOrder(TreeNode<T> node)
        {
            if (node.Left is not null)
            {
                foreach (var left in TraverseInOrder(node.Left))
                {
                    yield return left;
                }
            }

            yield return node.Value;

            if (node.Right is not null)
            {
                foreach (var right in TraverseInOrder(node.Right))
                {
                    yield return right;
                }
            }
        }

        public IEnumerable<T> TraversePostOrder()
        {
            if (_root is null) yield break;
            foreach (var item in TraversePostOrder(_root))
            {
                yield return item;
            }
        }
        private static IEnumerable<T> TraversePostOrder(TreeNode<T> node)
        {
            if (node.Left is not null)
            {
                foreach (var left in TraversePostOrder(node.Left))
                {
                    yield return left;
                }
            }

            if (node.Right is not null)
            {
                foreach (var right in TraversePostOrder(node.Right))
                {
                    yield return right;
                }
            }
            yield return node.Value;
        }

        public IEnumerable<T> TraversePreOrder()
        {
            if (_root is null) yield break;
            foreach (var item in TraversePreOrder(_root))
            {
                yield return item;
            }
        }
        private static IEnumerable<T> TraversePreOrder(TreeNode<T> node)
        {
            yield return node.Value;
            if (node.Left is not null)
            {
                foreach (var left in TraversePreOrder(node.Left))
                {
                    yield return left;
                }
            }
            if (node.Right is not null)
            {
                foreach (var right in TraversePreOrder(node.Right))
                {
                    yield return right;
                }
            }
        }
    }
}