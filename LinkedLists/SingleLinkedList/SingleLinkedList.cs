using System.Collections;

namespace LinkedLists.SingleLinkedList;

public class SingleLinkedList<T> : IEnumerable<T>
{
    private Node<T>? Head { get; set; }
    public int Length { get; private set; } = 0;
    public void PushBack(T value)
    {
        Node<T> newNode = new() { Value = value };
        if (Head is null)
        {
            Head = newNode;
            Length++;
            return;
        }

        Node<T> current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        current.Next = newNode;
        Length++;
    }
    public void PushFront(T value)
    {
        Node<T> newNode = new() { Value = value, Next = Head };
        Head = newNode;
        Length++;
    }

    public void Remove(T value)
    {
        if (Head is null) return;
        if (Head.Value.Equals(value))
        {
            Head = Head.Next;
            Length--;
            return;
        }
        Node<T> current = Head;
        while (current.Next is not null)
        {
            if (current.Next.Value.Equals(value))
            {
                current.Next = current.Next.Next;
                Length--;
                return;
            }
            current = current.Next;
        }
    }
    public void RemoveFirst()
    {
        if (Head is null) return;
        Head = Head.Next;
        Length--;
    }
    public void RemoveLast()
    {
        if (Head is null) return;
        if (Head.Next is null)
        {
            Head = null;
            Length--;
            return;
        }
        Node<T> current = Head;
        while (current.Next.Next is not null)
        {
            current = current.Next;
        }
        current.Next = null;
        Length--;
    }
    public void RemoveAt(int index)
    {
        if (Head is null) return;
        if (index == 0)
        {
            RemoveFirst();
            return;
        }
        Node<T> current = Head;
        int currentIndex = 0;
        while (current.Next is not null)
        {
            if (currentIndex == index - 1)
            {
                current.Next = current.Next.Next;
                Length--;
                return;
            }
            current = current.Next;
            currentIndex++;
        }
    }
    public bool Contains(T value)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    public T? GetFirst()
    {
        if (Head is null) return default;
        return Head.Value;
    }
    public T? GetLast()
    {
        if (Head is null) return default;
        Node<T> current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        return current.Value;
    }
    public void Clear()
    {
        Head = null;
        Length = 0;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}