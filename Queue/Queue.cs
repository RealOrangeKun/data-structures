using System.Collections;

namespace Queue;

public class Queue<T> : IQueue<T>, IEnumerable<T>
{
    public int Count { get; private set; } = 0;
    private T[] _items = new T[4];
    private int _head;
    private int _tail;

    public void Clear()
    {
        _items = new T[4];
        Count = 0;
        _head = 0;
        _tail = 0;
    }

    public T? Dequeue()
    {
        if (IsEmpty()) return default;
        T item = _items[_head];
        _head++;
        Count--;

        if (IsEmpty())
        {
            _head = 0;
            _tail = 0;
        }

        return item;
    }

    public void Enqueue(T value)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[_tail] = value;
        _tail++;
        Count++;
    }

    private void Resize()
    {
        int newSize = _items.Length * 2;
        T[] newArray = new T[newSize];
        Array.Copy(_items, _head, newArray, 0, Count);
        _items = newArray;
        _tail = Count;
        _head = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _head; i < _tail; i++)
        {
            yield return _items[i];
        }
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public T? Peek()
    {
        if (IsEmpty()) return default;
        return _items[_head];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
