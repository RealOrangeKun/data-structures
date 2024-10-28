namespace SegmentTree;

public class SegmentTree<T> where T : struct
{
    private readonly T[] _tree;
    private readonly int _n;
    public SegmentTree(T[] arr)
    {
        _n = arr.Length;
        _tree = new T[4 * _n];
        Build(arr, 0, 0, _n - 1);
    }
    private void Build(T[] arr, int node, int start, int end)
    {
        if (start == end)
        {
            _tree[node] = arr[start];
            return;
        }
        int mid = (start + end) / 2;
        Build(arr, GetLeftChildIndex(node), start, mid);
        Build(arr, GetRightChildIndex(node), mid + 1, end);
        _tree[node] = (dynamic)_tree[GetLeftChildIndex(node)] + (dynamic)_tree[GetRightChildIndex(node)];

    }
    private static int GetLeftChildIndex(int index) => 2 * index + 1;
    private static int GetRightChildIndex(int index) => 2 * index + 2;
    public bool Update(int index, T value) => Update(0, 0, _n - 1, index, value);
    private bool Update(int node, int start, int end, int index, T value)
    {
        if (index < 0 || index >= _n) return false;
        if (start == end)
        {
            _tree[node] = value;
            return true;
        }
        int mid = (start + end) / 2;
        bool updated;
        if (index <= mid)
            updated = Update(GetLeftChildIndex(node), start, mid, index, value);
        else
            updated = Update(GetRightChildIndex(node), mid + 1, end, index, value);
        _tree[node] = Add(_tree[GetLeftChildIndex(node)], _tree[GetRightChildIndex(node)]);
        return updated;
    }
    public T Query(int left, int right) => Query(0, 0, _n - 1, left, right);
    private T Query(int node, int start, int end, int left, int right)
    {
        if (right < start || left > end)
            return default;
        if (left <= start && end <= right)
            return _tree[node];
        int mid = (start + end) / 2;
        T leftResult = Query(GetLeftChildIndex(node), start, mid, left, right);
        T rightResult = Query(GetRightChildIndex(node), mid + 1, end, left, right);
        return Add(leftResult, rightResult);
    }
    private static T Add(T a, T b) => (dynamic)a + (dynamic)b;
}
