namespace ProblemSolving
{
    public class LazySegmentTree<TValue, TLazy>
    {
        private TValue[] _tree;
        private IMonoid<TValue> _monoid;
        
        private TLazy[] _lazy;
        private ILazyPropagate<TValue, TLazy> _lazyPropagate;
        
        private int _boundMin;
        private int _boundMax;
        
        #region Public Methods
        public LazySegmentTree(
            int boundMin, 
            int boundMax, 
            IMonoid<TValue> monoid, 
            ILazyPropagate<TValue, TLazy> lazyPropagate)
        {
            _boundMin = boundMin;
            _boundMax = boundMax;
            _monoid = monoid;
            _lazyPropagate = lazyPropagate;
            
            Initialize();
        }
        
        public void Update(int l, int r, Func<TLazy, TLazy> lazyUpdate)
        {
            UpdateInternal(_boundMin, _boundMax, 1, l, r, lazyUpdate);
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
            _lazy = new TLazy[treeSize];
            for (int i = 0; i < treeSize; i++)
            {
                _tree[i] = _monoid.Identity;
                _lazy[i] = _lazyPropagate.Default;
            }
        }

        private void Propagate(int l, int r, int idx)
        {
            if (l != r)
            {
                _lazy[idx << 1] = _lazyPropagate.AddLazy(_lazy[idx << 1], _lazy[idx]);
                _lazy[idx << 1 | 1] = _lazyPropagate.AddLazy(_lazy[idx << 1 | 1], _lazy[idx]);
            }

            _tree[idx] = _lazyPropagate.ApplyLazy(l, r, _tree[idx], _lazy[idx]);
            _lazy[idx] = _lazyPropagate.Default;
        }

        private void UpdateInternal(int l, int r, int idx, int i, int j, Func<TLazy, TLazy> lazyUpdate)
        {
            Propagate(l, r, idx);
            
            if (r < i || j < l) return;

            if (i <= l && r <= j)
            {
                _lazy[idx] = lazyUpdate(_lazy[idx]);
                Propagate(l, r, idx);
                return;
            }

            int mid = (l + r) >> 1;
            UpdateInternal(l, mid, idx << 1, i, j, lazyUpdate);
            UpdateInternal(mid + 1, r, idx << 1 | 1, i, j, lazyUpdate);
            _tree[idx] = _monoid.Operation.Operate(_tree[idx << 1], _tree[idx << 1 | 1]);
        }
        
        private TValue QueryInternal(int l, int r, int idx, int i, int j)
        {
            Propagate(l, r, idx);
            
            if (r < i || j < l) return _monoid.Identity;

            if (i <= l && r <= j) return _tree[idx];

            int mid = (l + r) >> 1;
            var left = QueryInternal(l, mid, idx << 1, i, j);
            var right = QueryInternal(mid + 1, r, idx << 1 | 1, i, j);
            return _monoid.Operation.Operate(left, right);
        }
        #endregion
    }
}