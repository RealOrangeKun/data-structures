using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashTable
{
    public struct Entry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsDeleted { get; set; }
    }
}