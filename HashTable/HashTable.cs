using System.Drawing;

namespace HashTable;

public class HashTable<TKey, TValue>(int size = 16) : IHashTable<TKey, TValue>
{
    public int Count { get; private set; }
    private int Size { get; set; } = size;
    private Entry<TKey, TValue>[] _entries = new Entry<TKey, TValue>[size];
    private const double LoadFactor = 0.75;

    private static int QuadraticProbe(int oldIndex, int attempt, int size)
    {
        return (oldIndex + attempt * attempt) % size;
    }

    private static int GetHash(TKey key, int size)
    {
        return Math.Abs(key.GetHashCode()) % size;
    }
    public void Add(TKey key, TValue value)
    {
        if (Count >= Size * LoadFactor)
        {
            Resize();
        }
        int index = HashTable<TKey, TValue>.GetHash(key, Size);
        for (int i = 0; i < Size; i++)
        {
            int probeIndex = HashTable<TKey, TValue>.QuadraticProbe(index, i, Size);
            if (!_entries[probeIndex].IsOccupied || _entries[probeIndex].IsDeleted)
            {
                _entries[probeIndex].Key = key;
                _entries[probeIndex].Value = value;
                _entries[probeIndex].IsOccupied = true;
                _entries[probeIndex].IsDeleted = false;
                Count++;
                return;
            }
            else if (_entries[probeIndex].Key.Equals(key))
            {
                _entries[probeIndex].Value = value;
                return;
            }
        }
        throw new InvalidOperationException("Hash table is full");
    }

    private void Resize()
    {
        int newSize = PrimeUtility.GetNextPrime(Size * 2);
        var newEntries = new Entry<TKey, TValue>[newSize];
        Count = 0;
        foreach (var entry in _entries)
        {
            if (entry.IsOccupied && !entry.IsDeleted)
            {
                int newIndex = HashTable<TKey, TValue>.GetHash(entry.Key, newSize);
                for (int i = 0; i < newSize; i++)
                {
                    int probeIndex = HashTable<TKey, TValue>.QuadraticProbe(newIndex, i, newSize);
                    if (!newEntries[probeIndex].IsOccupied)
                    {
                        newEntries[probeIndex].Key = entry.Key;
                        newEntries[probeIndex].Value = entry.Value;
                        newEntries[probeIndex].IsOccupied = true;
                        newEntries[probeIndex].IsDeleted = false;
                        Count++;
                        break;
                    }
                }
            }
        }
        _entries = newEntries;
        Size = newSize;
    }

    public void Clear()
    {
        _entries = new Entry<TKey, TValue>[Size];
        Count = 0;
    }

    public bool ContainsKey(TKey key)
    {
        if (Count == 0) return false;
        int index = HashTable<TKey, TValue>.GetHash(key, Size);
        for (int i = 0; i < Size; i++)
        {
            int probeIndex = HashTable<TKey, TValue>.QuadraticProbe(index, i, Size);
            if (!_entries[probeIndex].IsOccupied || _entries[probeIndex].IsDeleted)
            {
                return false;
            }
            else if (_entries[probeIndex].Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }

    public bool Remove(TKey key)
    {
        if (Count == 0) return false;
        if (!ContainsKey(key)) return false;
        int index = HashTable<TKey, TValue>.GetHash(key, Size);
        for (int i = 0; i < Size; i++)
        {
            int probeIndex = HashTable<TKey, TValue>.QuadraticProbe(index, i, Size);
            if (!_entries[probeIndex].IsOccupied || _entries[probeIndex].IsDeleted)
            {
                return false;
            }
            else if (_entries[probeIndex].Key.Equals(key))
            {
                _entries[probeIndex].IsDeleted = true;
                Count--;
                return true;
            }
        }
        return false;
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        int index = HashTable<TKey, TValue>.GetHash(key, Size);
        for (int i = 0; i < Size; i++)
        {
            int probeIndex = HashTable<TKey, TValue>.QuadraticProbe(index, i, Size);
            if (!_entries[probeIndex].IsOccupied || _entries[probeIndex].IsDeleted)
            {
                value = default;
                return false;
            }
            else if (_entries[probeIndex].Key.Equals(key))
            {
                value = _entries[probeIndex].Value;
                return true;
            }
        }
        value = default;
        return false;
    }
}
