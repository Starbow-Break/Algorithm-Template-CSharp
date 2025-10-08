namespace ProblemSolving.DataStructure;

/*
 * Class implementing a SegmentTree
 * Author : STARBOW
 */

public class SegmentTree<TValue>
{
    private TValue[] _tree;
    private IMonoid<TValue> _monoid;
    
    private int _boundMin;
    private int _boundMax;

    #region Public Methods
    public SegmentTree(int boundMin, int boundMax, IMonoid<TValue> monoid)
    {
        _boundMin = boundMin;
        _boundMax = boundMax;
        _monoid = monoid;

        Initialize();
    }
    
    public void Update(int t, Func<TValue, TValue> update)
    {
        UpdateInternal(_boundMin, _boundMax, 1, t, update);
    }
    
    public TValue Query(int l, int r)
    {
        return QueryInternal(_boundMin, _boundMax, 1, l, r);
    }
    #endregion

    #region Private Methods

    private void Initialize()
    {
        int treeSize = 1;
        while (treeSize <= 2 * (_boundMax - _boundMin + 1))
        {
            treeSize *= 2;
        }

        _tree = new TValue[treeSize];
        for (int i = 0; i < treeSize; i++)
        {
            _tree[i] = _monoid.Identity;
        }
    }
    
    private void UpdateInternal(int l, int r, int idx, int t, Func<TValue, TValue> update)
    {
        if (r < t || t < l) return;

        if (t <= l && r <= t)
        {
            _tree[idx] = update(_tree[idx]);
            return;
        }

        int mid = (l + r) >> 1;
        UpdateInternal(l, mid, idx << 1, t, update);
        UpdateInternal(mid + 1, r, idx << 1 | 1, t, update);
        _tree[idx] = _monoid.Operation.Operate(_tree[idx << 1], _tree[idx << 1 | 1]);
    }
    
    private TValue QueryInternal(int l, int r, int idx, int i, int j)
    {
        if (r < i || j < l) return _monoid.Identity;

        if (i <= l && r <= j) return _tree[idx];

        int mid = (l + r) >> 1;
        var left = QueryInternal(l, mid, idx << 1, i, j);
        var right = QueryInternal(mid + 1, r, idx << 1 | 1, i, j);
        return _monoid.Operation.Operate(left, right);
    }
    #endregion
}