/*
 * Interface of Monoid Algebraic Structure
 *
 * Operation - Binary Operation of Monoid
 * The operation must satisfy the following two conditions.
 * associativity - Op(Op(a, b), c) == Op(a, Op(b, c))
 * identity - There is exist value e for any value a, such that Op(a, e) == Op(e, a) and Op(a, e) == a
 *
 * Identity - Identity value of Binary Operation
 * 
 * Author : STARBOW
 */

namespace ProblemSolving
{
    public interface IMonoid<T>
    {
        public T Identity { get; }
        public IBinaryOperation<T> Operation { get; }
    }
}