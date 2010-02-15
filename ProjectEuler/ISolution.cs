using System;
using System.Linq.Expressions;

namespace ProjectEuler
{
    public interface ISolution
    {        
        object Result { get; }
    }

    public static class Solution
    {
        public static Solution<T> Create<T>(Expression<Func<T>> expression)
        {
            return new Solution<T>(expression);
        }
    }

    public class Solution<T> : ISolution
    {
        public Solution(Expression<Func<T>> expression)
        {
            SolutionExpression = expression;
            Result = expression.Compile()();
        }

        public Expression<Func<T>> SolutionExpression { get; private set; }
        public T Result { get; private set; }

        object ISolution.Result
        {
            get { return Result; }
        }

        public override string ToString()
        {
            return SolutionExpression.ToString();
        }
    }
}