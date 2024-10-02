namespace HashTable;

public interface IHashTable<TKey, TValue>
{
    void Add(TKey key, TValue value);
    bool Remove(TKey key);
    bool TryGetValue(TKey key, out TValue? value);
    bool ContainsKey(TKey key);
    void Clear();
}
