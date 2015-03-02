using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    static class Program {

        static int factorial(int n) {
            return n == 0
                ? 1
                : n * factorial(n - 1);
        }

        static int fibonacci(int n) {
            return n < 2
                ? 1
                : fibonacci(n-1) + fibonacci(n-2);
        }

        static int sum(IEnumerable<int> list) {
            return list.Count() == 0
                ? 0
                : list.ElementAt(0) + sum(list.Skip(1));
        }

        static int count(int item, IEnumerable<int> list) {
            return list.Count() == 0
                ? 0
                : (list.ElementAt(0) == item ? 0 : 1) + count(item, list.Skip(1));
        }

        static bool isEven(int num) { return num % 2 == 0; }

        static string print(this LinkedList<int> list) {
            return list.Aggregate( "", (acc, elem) => acc + "," + elem);
        }

        static LinkedList<int> evens(LinkedList<int> list) {
            if( list.Count() == 0 )
                return new LinkedList<int>();
            if (isEven(list.First.Value)) {
                var head = list.First.Value;
                list.RemoveFirst();
                var rest = evens(list);
                rest.AddFirst(head);
                return rest;
            }
            else {
                list.RemoveFirst();
                return evens(list);
            }
        }

        static void Main(string[] args) {

            Console.WriteLine("Factorial 5: {0}", factorial(5));
            Console.WriteLine("Fibonacci 7: {0}", fibonacci(7));
            Console.WriteLine("Sum [1;2;3;4;5] = {0}", sum(new List<int> {1,2,3,4,5}));
            Console.WriteLine("Count 1 [1,2,1,3,4,1] = {0}", count(1, new List<int> { 1, 2, 1, 3, 4, 1 }));
            Console.WriteLine("Evens [1,2,3,4,5,6,7,8] = {0}", evens(new LinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 })).print());
        }
    }
}
