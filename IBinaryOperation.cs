/*
 * Interface of Binary Operation
 * Author : STARBOW
 */

namespace ProblemSolving
{
    public interface IBinaryOperation<TValue>
    {
        public TValue Operate(TValue first, TValue second);
    }
}