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
        public ISolution Solve()
        {
            var naturalsUnderOneThousand = Core.Range._(1, 999);
            var isMultipleOfThreeOrFive = Core.IsMultipleOf._(3).Or(Core.IsMultipleOf._(5));

            var solution = naturalsUnderOneThousand
                .Where(isMultipleOfThreeOrFive)
                .Sum();

            return Solution.Create(solution);            
        }
    }


}