namespace FenwickTree;
public interface IFenwickTree
{
    void Update(int index, int value);
    int Query(int index);
    int RangeQuery(int start, int end);
}