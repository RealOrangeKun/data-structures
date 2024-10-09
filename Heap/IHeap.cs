using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heap
{
    public interface IHeap<T>
    {
        void Insert(T element);
        T Remove();
        T Peek();
        bool IsEmpty();
        void Clear();
    }
}