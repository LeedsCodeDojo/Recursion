using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    static class Program {

        // LinkedList helpers

        // Head gets the first item
        static int Head(LinkedList<int> list) {
            return list.First.Value;
        }

        // Tail gets the whole list excliding the first item
        static LinkedList<int> Tail(LinkedList<int> list) {
            list.RemoveFirst();
            return list;
        }

        // Attaches the item onto the beginning of the list
        static LinkedList<int> Cons(int head, LinkedList<int> tail) {
            tail.AddFirst(head);
            return tail;
        }

        // Creates a LinkedList from a range of integers, one element per number
        static LinkedList<int> LinkedListRange(int from, int to) {
            return new LinkedList<int>(Enumerable.Range(from, to));
        }

        // Prints each item of a linked list
        static string print(this LinkedList<int> list) {
            return list.Aggregate("", (output, item) => output + "," + item).Substring(1);
        }

        // Example - recursively builds up a list by doubling everything in the passed list
        static LinkedList<int> double_everything(LinkedList<int> list) {
            if (list.Count() == 0)
                return new LinkedList<int>();
            else
                return Cons(Head(list)*2, double_everything(Tail(list)));
        }

        /***************************
         ********** Basic **********
         ***************************/

        static int factorial(int n) {
            return n == 0
                ? 1
                : n * factorial(n - 1);
        }

        static int factorial2(int n) {
            if( n == 0 )
                return 1;
            else
                return n * factorial2(n - 1);
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

        // this is really slow for longer lists
        static int count(int item, IEnumerable<int> list) {
            return list.Count() == 0
                ? 0
                : (list.ElementAt(0) == item ? 1 : 0) + count(item, list.Skip(1));
        }

        static bool even(int num) { return num % 2 == 0; }

        static LinkedList<int> evens(LinkedList<int> list) {
            if (list.Count() == 0)
                return new LinkedList<int>();
            else if (even(Head(list)))
                return Cons(Head(list), Tail(list));
            else 
                return evens(Tail(list));
        }

        static bool isEven(int n) {
          return n == 0 
              ? true
              : isOdd(n - 1);
        }

        static bool isOdd(int n) {
            return n == 0
                ? false
                : isEven(n - 1);
        }

        /**********************************
         ********** Intermediate **********
         **********************************/

        static int ackermann(int m, int n) {
            if (m == 0)
                return n + 1;
            else if (n == 0)
                return ackermann(m - 1, 1);
            else
                return ackermann(m - 1, ackermann(m, n - 1));
        }

        static bool treesearch(string filename, string path) {
            var filesFolders = new DirectoryInfo(path).EnumerateFileSystemInfos();

            if (filesFolders.Where(info => info.Name == filename).Count() > 0)
                return true;

            return filesFolders
                .Where( info => info is DirectoryInfo )
                .Any( directory => treesearch(filename, directory.FullName ));
        }

        static int count_quick(int item, LinkedList<int> list) {
            return list.Count() == 0
                ? 0
                : (list.First() == item ? 1 : 0) + count_quick(item, Tail(list));
        }

        static int count_tail(int item, LinkedList<int> list, int count) {
            if( list.Count() == 0 )
                return count;
            else
                return count_tail(item, Tail(list), count + (Head(list) == item ? 1 : 0));
        }

        static void Main(string[] args) {

            Console.WriteLine("Basic\n");
            Console.WriteLine("Factorial 5: {0}", factorial(5));
            Console.WriteLine("Fibonacci 7: {0}", fibonacci(7));
            Console.WriteLine("Sum [1;2;3;4;5] = {0}", sum(new List<int> {1,2,3,4,5}));
            Console.WriteLine("Count 1 [1,2,1,3,4,1] = {0}", count(1, new List<int> { 1, 2, 1, 3, 4, 1 }));
            Console.WriteLine("Evens [1,2,3,4,5,6,7,8] = {0}", evens(LinkedListRange(1,9)).print());
            Console.WriteLine("99 even? {0} 78 even? {1} 21 odd? {2}", isEven(99), isEven(78), isOdd(21));

            Console.WriteLine("\nIntermediate\n");
            Console.WriteLine("Ackermann 3 10: {0}", ackermann(3,10));
            Console.WriteLine("treesearch c:temp {0}", treesearch("thefile.txt", @"c:\temp"));
            Console.WriteLine("Count (quick) 99 [1..10000] = {0}", count_quick(99, LinkedListRange(0,10000)));
            Console.WriteLine("Count (tail) 99 [1..100000] = {0}", count_tail(99, LinkedListRange(0, 100000), 0));
        }
    }
}
