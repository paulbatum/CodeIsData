using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CodeIsData;

namespace ProjectEuler
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class Problem1 : IProblem
    {


        public static Expression<Func<IEnumerable<int>>> NaturalsUnderOneThousand = Core.Range.PartiallyEvaluate(1, 999);

        public static Expression<Func<int, int, bool>> MultipleOf = (int input, int divisor) => input % divisor == 0;
        public static Expression<Func<int, bool>> MultipleOfFive = i => i % 5 == 0;

        public static Expression<Func<int, bool>> MultipleOfThreeOrFive =
            i => MultipleOf.Compile()(i, 3) || MultipleOf.Compile()(i, 5);


        public ISolution Solve()
        {
            var solution = Solution.Create(() => NaturalsUnderOneThousand.Compile()()
                                                  .Where(MultipleOfThreeOrFive.Compile())
                                                  .Sum());

            return solution;
        }
    }


}