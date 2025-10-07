namespace ProblemSolving
{
    public class LazySegmentTree<TValue>
    {
        private TValue[] _tree;
        private int _boundMin;
        private int _boundMax;

        private IMonoid<TValue> _monoid;

        public LazySegmentTree(int boundMin, int boundMax, IMonoid<TValue> monoid)
        {
            _boundMin = boundMin;
            _boundMax = boundMax;
            _monoid = monoid;
        }

        // private void Propagate(int l, int r, int idx)
        // {
        //     if (l != r)
        //     {
        //         
        //     }
        // }
        
        private TValue Merge(TValue left, TValue right)
        {
            return _monoid.Operation.Operate(left, right);
        }

        private void UpdateInternal(int l, int r, int idx, int i, int j, Func<TValue, TValue> update)
        {
            //Propagate(l, r, idx);
            
            if (r < i || j < l) return;

            if (i <= l && r <= j)
            {
                //?
                //Propagate(l, r, idx);
                return;
            }

            int mid = (l + r) >> 1;
            UpdateInternal(l, mid, idx << 1, i, j, update);
            UpdateInternal(mid + 1, r, idx << 1 | 1, i, j, update);
            _tree[idx] = Merge(_tree[idx << 1], _tree[idx << 1 | 1]);
        }
        
        private TValue QueryInternal(int l, int r, int idx, int i, int j)
        {
            //Propagate(l, r, idx);
            
            if (r < i || j < l) return _monoid.Identity;

            if (i <= l && r <= j) return _tree[idx];

            int mid = (l + r) >> 1;
            var left = QueryInternal(l, mid, idx << 1, i, j);
            var right = QueryInternal(mid + 1, r, idx << 1 | 1, i, j);
            return Merge(left, right);
        }

        public void Update(int l, int r, Func<TValue, TValue> update)
        {
            UpdateInternal(_boundMin, _boundMax, 1, l, r, update);
        }
        
        public TValue Query(int l, int r)
        {
            return QueryInternal(_boundMin, _boundMax, 1, l, r);
        }
    }
}