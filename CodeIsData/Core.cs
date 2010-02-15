using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodeIsData
{
    public class Core
    {

        //public static Expression<Func<Unit, string>> ReadLine = _ => Console.ReadLine();
        //public static Expression<Func<string, Unit>> WriteLine = s => FunctionalExtensions.InvokeAndReturnUnit(Console.WriteLine, s);

        public static Expression<Func<int, int, IEnumerable<int>>> Range =
            (from, to) => Enumerable.Range(from, to - from + 1);

        public static Expression<Func<int, int, bool>> IsMultipleOf = 
            (divisor, input) => input % divisor == 0;

        
    }
}