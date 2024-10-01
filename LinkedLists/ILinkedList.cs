using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedLists
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        void PushBack(T value);
        void PushFront(T value);
        void Remove(T value);
        void RemoveFirst();
        void RemoveLast();
        void RemoveAt(int index);
        bool Contains(T value);
        T? GetFirst();
        T? GetLast();
        void Clear();
    }
}