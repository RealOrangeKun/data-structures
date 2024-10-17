
namespace IndexedPriorityQueue;
public interface IIndexedPriorityQueue<T>
{
    void Enqueue(T item, int priority);
    T? Dequeue();
    T? Peek();
    bool Contains(T item);
    void DecreaseKey(T item, int newPriority);
    bool IsEmpty();
    void Clear();
}
