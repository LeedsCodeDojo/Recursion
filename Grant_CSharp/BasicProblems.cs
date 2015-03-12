using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Solutions to the Basic problems
    /// </summary>
    public static class BasicProblems {

        public static bool even(int num) { return num % 2 == 0; }

        public static int factorial_conditional(int n) {
            return n == 0
                ? 1
                : n * factorial_conditional(n - 1);
        }

        public static int factorial_if(int n) {
            if (n == 0)
                return 1;
            else
                return n * factorial_if(n - 1);
        }

        public static int fibonacci(int n) {
            return n < 2
                ? 1
                : fibonacci(n - 1) + fibonacci(n - 2);
        }

        public static int sum(IEnumerable<int> list) {
            return list.Count() == 0
                ? 0
                : list.ElementAt(0) + sum(list.Skip(1));
        }

        public static int count(int item, IEnumerable<int> list) {
            return list.Count() == 0
                ? 0
                : (list.ElementAt(0) == item ? 1 : 0) + count(item, list.Skip(1));
        }

        public static LinkedList<int> evens(LinkedList<int> list) {
            if (list.Count() == 0)
                return new LinkedList<int>();
            else if (even(list.Head()))
                return list.Head().Cons(evens(list.Tail()));
            else
                return evens(list.Tail());
        }

        public static bool isEven(int n) {
            return n == 0
                ? true
                : isOdd(n - 1);
        }

        public static bool isOdd(int n) {
            return n == 0
                ? false
                : isEven(n - 1);
        }
    }
}
