using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodeIsData
{
    public static class FunctionalExtensions
    {
        //public static Unit InvokeAndReturnUnit<TInput>(Action<TInput> action, TInput arg)
        //{
        //    action(arg);
        //    return new Unit();            
        //}



        public static Expression<Func<bool>> Or(this Expression<Func<bool>> lhs,  Expression<Func<bool>> rhs)
        {
            return () => lhs.Compile()() || rhs.Compile()();
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> lhs, Expression<Func<T, bool>> rhs)
        {
            return t => lhs.Compile()(t) || rhs.Compile()(t);
        }



        public static Expression<Func<IEnumerable<T>>> Where<T>(this Expression<Func<IEnumerable<T>>> items, Expression<Func<T, bool>> predicate)
        {
            return () => items.Compile()().Where(predicate.Compile());
        }

        public static Expression<Func<int>> Sum(this Expression<Func<IEnumerable<int>>> items)
        {
            return () => items.Compile()().Sum();
        }



        public static Expression<Func<T2, TResult>> _<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expression, T1 t1)
        {
            return a => expression.Compile()(t1, a);
        }

        public static Expression<Func<TResult>> _<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expression, T1 t1, T2 t2)
        {
            return () => expression.Compile()(t1, t2);
        }



        

        //public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> function)
        //{
        //    return a => b => c => function(a, b, c);
        //}

        //public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> function)
        //{
        //    return a => b => c => d => function(a, b, c, d);
        //}
    }
}