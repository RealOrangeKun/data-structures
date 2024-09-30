namespace SingleLinkedList
{
    public class Node<T>
    {
        public required T Value { get; set; }
        public Node<T>? Next { get; set; }
    }
}