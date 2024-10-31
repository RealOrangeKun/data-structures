namespace FenwickTree;

public class FenwickTree : IFenwickTree
{
    private readonly List<int> _tree = [0];
    public FenwickTree(IEnumerable<int> values)
    {
        int n = values.Count();
        _tree.AddRange(values);
        for (int i = 1; i <= n; i++)
        {
            int j = i + LSB(i);
            if (j > n) continue;
            _tree[j] += _tree[i];
        }
    }
    public int Query(int index)
    {
        int i = index;
        int sum = 0;
        while (i > 0)
        {
            sum += _tree[i];
            i -= LSB(i);
        }
        return sum;
    }

    public int RangeQuery(int start, int end)
    {
        return Query(end) - Query(start - 1);
    }

    public void Update(int index, int value)
    {
        int i = index;
        while (i < _tree.Count)
        {
            _tree[i] += value;
            i += LSB(i);
        }
    }
    private static int LSB(int x)
    {
        return x & -x;
    }
}
