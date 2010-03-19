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
        /// <summary>
        /// (sum
        ///   (filter 
        ///      (range 1 999)
        ///      (or
        ///         (is-multiple-of 3)
        ///         (is-multiple-of 5)
        ///      )
        ///   )
        /// )
        /// </summary>
        /// <returns></returns>
        public ISolution Solve()
        {
            //var solution = Core.Range._(1, 999)
            //    .Where(Core.IsMultipleOf._(3).Or(Core.IsMultipleOf._(5)))
            //    .Sum();

            var solution = FunctionalExtensions.Sum(
                FunctionalExtensions.Where(
                    Core.Range._(1, 999),
                    FunctionalExtensions.Or(
                        Core.IsMultipleOf._(3),
                        (Core.IsMultipleOf._(5))
                        )                    
                    )
                );

            return Solution.Create(solution);            
        }
    }


}