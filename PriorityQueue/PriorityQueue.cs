using System.Collections;
using Heap;

namespace PriorityQueue;

public class PriorityQueue<T>(Priority priority) : IPriorityQueue<T>, IEnumerable<T> where T : IComparable
{
    private readonly Heap<T> _heap = new(priority == Priority.Maximum ? HeapType.MaxHeap : HeapType.MinHeap);
    public int Count => _heap.Count;
    public void Clear()
    {
        _heap.Clear();
    }

    public T Dequeue()
    {
        return _heap.Remove();
    }

    public void Enqueue(T item)
    {
        _heap.Insert(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _heap)
        {
            yield return item;
        }
    }

    public bool IsEmpty()
    {
        return _heap.IsEmpty();
    }

    public T Peek()
    {
        return _heap.Peek();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
