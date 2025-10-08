namespace ProblemSolving;
    
/*
 * Interface of Binary Operation
 * Author : STARBOW
 */

public interface IBinaryOperation<TValue>
{
    public TValue Operate(TValue first, TValue second);
}