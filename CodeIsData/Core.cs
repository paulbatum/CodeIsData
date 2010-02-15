using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodeIsData
{
    public class Core
    {

        public static Expression<Func<Unit, string>> ReadLine = _ => Console.ReadLine();
        public static Expression<Func<string, Unit>> WriteLine = s => FunctionalExtensions.InvokeAndReturnUnit(Console.WriteLine, s);

        public static Expression<Func<int, int, IEnumerable<int>>> Range =
            (from, to) => Enumerable.Range(from, to - from + 1);

        
    }

    public static class FunctionalExtensions
    {
        public static Unit InvokeAndReturnUnit<TInput>(Action<TInput> action, TInput arg)
        {
            action(arg);
            return new Unit();            
        }

        public static Expression<Func<TOutput>> PartiallyEvaluate<TInput1, TInput2, TOutput>(this Expression<Func<TInput1, TInput2, TOutput>> expression, TInput1 input1, TInput2 input2)
        {
            return () => expression.Compile()(input1, input2);
        }

        //public static Func<T1, Func<T2, TOutput>> Curry<T1, T2, TOutput>(this Expression<Func<T1, T2, TOutput>> function)
        //{
        //    return a => b => function.Compile()(a, b);
        //}

        //public static Func<T1, Func<T2, Func<T3, TOutput>>> Curry<T1, T2, T3, TOutput>(this Func<T1, T2, T3, TOutput> function)
        //{
        //    return a => b => c => function(a, b, c);
        //}

        //public static Func<T1, Func<T2, Func<T3, Func<T4, TOutput>>>> Curry<T1, T2, T3, T4, TOutput>(this Func<T1, T2, T3, T4, TOutput> function)
        //{
        //    return a => b => c => d => function(a, b, c, d);
        //}
    }
}