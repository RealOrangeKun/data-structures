namespace PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        bool IsEmpty();
        void Clear();
    }
}