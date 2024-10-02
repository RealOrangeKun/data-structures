using System.Collections;

namespace LinkedLists.DoublyLinkedList;

public class DoublyLinkedList<T> : ILinkedList<T>, IEnumerable<T>
{
    private Node<T>? Head { get; set; }
    public int Length { get; private set; }
    public void Clear()
    {
        Head = null;
        Length = 0;
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

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
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

    public void PushBack(T value)
    {
        if (Head is null)
        {
            Head = new() { Value = value };
            Length++;
            return;
        }

        Node<T> current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        current.Next = new() { Value = value, Previous = current };
        Length++;
    }

    public void PushFront(T value)
    {
        if (Head is null)
        {
            Head = new() { Value = value };
            Length++;
            return;
        }
        Head.Previous = new() { Value = value, Next = Head };
        Head = Head.Previous;
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
                if (current.Next.Next is not null)
                    current.Next.Next.Previous = current;
                current.Next = current.Next.Next;
                Length--;
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (Head is null) return;
        if (index == 0)
        {
            RemoveFirst();
            return;
        }
        else if (index == Length - 1)
        {
            RemoveLast();
            return;
        }
        Node<T> current = Head;
        int currentIndex = 0;
        while (current.Next is not null)
        {
            if (currentIndex == index - 1)
            {
                if (current.Next.Next is not null)
                    current.Next.Next.Previous = current;
                current.Next = current.Next.Next;
                Length--;
                return;
            }
            current = current.Next;
            currentIndex++;
        }
    }

    public void RemoveFirst()
    {
        if (Head is null) return;
        if (Head.Next is null)
        {
            Head = null;
            Length--;
            return;
        }
        Head.Next.Previous = null;
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

