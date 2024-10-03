namespace BinaryTrees
{
    public class TreeNode<T>
    {
        public required T Value { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }
    }
}