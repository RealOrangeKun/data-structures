using System.Collections;

namespace Stack;

public class Stack<T> : IStack<T>, IEnumerable<T>
{
    public int Count { get; private set; }
    private T[] _items = [];
    public void Clear()
    {
        _items = [];
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = Count - 1; i >= 0; i--)
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
        return _items[Count - 1];
    }

    public T? Pop()
    {
        if (IsEmpty()) return default;
        var item = _items[Count - 1];
        Count--;
        return item;
    }

    public void Push(T value)
    {
        if (Count == _items.Length)
        {
            Resize();
        }
        _items[Count] = value;
        Count++;
    }
    private void Resize()
    {
        int newSize = _items.Length == 0 ? 4 : _items.Length * 2;
        Array.Resize(ref _items, newSize);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
