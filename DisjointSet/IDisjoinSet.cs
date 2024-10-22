namespace DisjointSet;
public interface IDisjoinSet<T>
{
    void MakeSet(T item);
    T Find(T item);
    void Union(T item1, T item2);
}