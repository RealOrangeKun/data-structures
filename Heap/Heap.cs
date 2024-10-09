using System.Collections;

namespace Heap;

public class Heap<T>(HeapType heapType) : IHeap<T>, IEnumerable<T> where T : IComparable
{
    private T[] _items = new T[16];
    public int Count { get; private set; }
    private readonly HeapType _heapType = heapType;
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }

    public void Insert(T element)
    {
        if (Count == _items.Length)
            Resize();
        _items[Count] = element;
        HeapifyUp(Count);
        Count++;

    }
    private void Resize()
    {
        int newSize = _items.Length * 2;
        T[] newArray = new T[newSize];
        Array.Copy(_items, newArray, Count);
        _items = newArray;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The heap is empty");
        return _items[0];
    }

    public T Remove()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The heap is empty");
        T item = _items[0];
        _items[0] = _items[Count - 1];
        Count--;
        HeapifyDown(0);
        return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private void HeapifyUp(int index)
    {
        int parentIndex = Heap<T>.GetParentIndex(index);
        bool condition = _heapType == HeapType.MinHeap ? _items[index].CompareTo(_items[parentIndex]) < 0
        : _items[index].CompareTo(_items[parentIndex]) > 0;
        if (index > 0 && condition)
        {
            Swap(index, parentIndex);
            HeapifyUp(parentIndex);
        }
    }
    private void HeapifyDown(int index)
    {
        int leftChildIndex = Heap<T>.GetLeftChildIndex(index);
        int rightChildIndex = Heap<T>.GetRightChildIndex(index);
        int targetIndex = index;

        if (leftChildIndex < Count)
        {
            bool leftCondition = (_heapType == HeapType.MinHeap)
                ? _items[leftChildIndex].CompareTo(_items[targetIndex]) < 0
                : _items[leftChildIndex].CompareTo(_items[targetIndex]) > 0;

            if (leftCondition)
            {
                targetIndex = leftChildIndex;
            }
        }

        if (rightChildIndex < Count)
        {
            bool rightCondition = (_heapType == HeapType.MinHeap)
                ? _items[rightChildIndex].CompareTo(_items[targetIndex]) < 0
                : _items[rightChildIndex].CompareTo(_items[targetIndex]) > 0;

            if (rightCondition)
            {
                targetIndex = rightChildIndex;
            }
        }
        if (targetIndex != index)
        {
            Swap(index, targetIndex);
            HeapifyDown(targetIndex);
        }
    }
    private static int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }
    private static int GetLeftChildIndex(int index)
    {
        return 2 * index + 1;
    }
    private static int GetRightChildIndex(int index)
    {
        return 2 * index + 2;
    }
    private void Swap(int i, int j)
    {
        (_items[j], _items[i]) = (_items[i], _items[j]);
    }

    public void Clear()
    {
        _items = new T[16];
        Count = 0;
    }
}
