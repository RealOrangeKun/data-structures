namespace BinaryTrees
{
    public interface IBinaryTree<T>
    {
        void Insert(T value);
        bool Contains(T value);
        void Remove(T value);
        IEnumerable<T> TraverseInOrder();
        IEnumerable<T> TraversePreOrder();
        IEnumerable<T> TraversePostOrder();
    }
}
