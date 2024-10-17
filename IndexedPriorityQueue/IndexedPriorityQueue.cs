using Heap;
using PriorityQueue;

namespace IndexedPriorityQueue;

public class IndexedPriorityQueue<T>(Priority priority) : IIndexedPriorityQueue<T> where T : IComparable
{
    private readonly Heap<(int, T)> _heap = new(priority == Priority.Minimum ?
    HeapType.MinHeap :
    HeapType.MaxHeap);
    private readonly Dictionary<T, int> _map = [];

    public void Clear()
    {
        _heap.Clear();
        _map.Clear();
    }

    public bool Contains(T item)
    {
        if (IsEmpty())
            return false;

        return _map.ContainsKey(item);
    }

    public void DecreaseKey(T item, int newPriority)
    {
        if (!Contains(item))
            return;
        var index = _map[item];
        var element = _heap.PeekAt(index);
        if (newPriority >= element.Item1) return;
        _heap.UpdateAt(index, (newPriority, item));
        RebuildMap();
    }

    public T? Dequeue()
    {
        if (IsEmpty())
            return default;
        var item = _heap.Remove();
        _map.Remove(item.Item2);
        return item.Item2;
    }

    public void Enqueue(T item, int priority)
    {
        if (_map.ContainsKey(item)) return;
        _heap.Insert((priority, item));
        _map[item] = _heap.Count - 1;
    }

    public bool IsEmpty() => _heap.IsEmpty();


    public T? Peek()
    {
        if (IsEmpty())
            return default;
        return _heap.Peek().Item2;
    }
    private void RebuildMap()
    {
        _map.Clear();
        for (int i = 0; i < _heap.Count; i++)
        {
            _map[_heap.PeekAt(i).Item2] = i;
        }
    }

}
