namespace DisjointSet;

public class DisjointSet<T> : IDisjoinSet<T> where T : IComparable
{
    private readonly Dictionary<T, T> parent = [];
    private readonly Dictionary<T, int> size = [];
    public T Find(T item)
    {
        if (!parent.TryGetValue(item, out T? value)) throw new ArgumentException("Item not found in any set.");
        if (!item.Equals(value))
        {
            parent[item] = Find(value);
        }
        return parent[item];

    }

    public void MakeSet(T item)
    {
        if (parent.ContainsKey(item)) throw new ArgumentException("Set already exists");
        parent[item] = item;
        size[item] = 1;
    }

    public void Union(T item1, T item2)
    {
        T parent1 = Find(item1);
        T parent2 = Find(item2);
        if (parent1.Equals(parent2)) return;
        if (size[parent1] < size[parent2])
        {
            parent[parent1] = parent2;
            size[parent2]++;
        }
        else
        {
            parent[parent2] = parent1;
            size[parent1]++;
        }
    }
}
