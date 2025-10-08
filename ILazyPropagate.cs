namespace ProblemSolving;

public interface ILazyPropagate<TValue, TLazy>
{
    public TLazy Default { get; }
    public TLazy AddLazy(TLazy currentLazy, TLazy addLazy);
    public TValue ApplyLazy(int nodeBoundMin, int nodeBoundMax, TValue nodeValue, TLazy lazyValue);
}