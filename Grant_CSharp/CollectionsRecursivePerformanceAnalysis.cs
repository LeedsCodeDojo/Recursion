using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecursiveLinkedList = Recursion_Solutions_CSharp.LinkedListRecursionExtensions;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Trying out different collection types for working recursively.
    /// 
    /// Looking at how List, LinkedList, Array and a custom-made type
    /// when used for the 'count' and 'evens' problems.
    /// </summary>
    public static class CollectionsRecursivePerformanceAnalysis {

        public static bool even(int num) { return num % 2 == 0; }
        private static int listLength = 1000;

        private static void Analyse(Action recursiveProcess, string name) {
            GC.Collect();
            Thread.Sleep(100);
            var startMemory = Process.GetCurrentProcess().WorkingSet64;
            var timer = Stopwatch.StartNew();
            recursiveProcess.Invoke();
            var ms = timer.ElapsedMilliseconds;
            var usedMemory = Process.GetCurrentProcess().WorkingSet64 - startMemory;
            Console.WriteLine("{0} runs {1} iterations in {2}ms using roughly {3}Mb peak memory", name, listLength, ms, usedMemory/1024/1024);
        }

        public static void TestSolutions() {

            Console.WriteLine("Testing solutions...");

            // count (non tail recursive)
            Debug.Assert(EnumerableSolutions.count(9, Enumerable.Range(0, 10)) == 1);
            Debug.Assert(EnumerableSolutions.count(99, Enumerable.Range(0, 10)) == 0);

            Debug.Assert(LinkedListSolutions.count(9, RecursiveLinkedList.FromRange(0, 10)) == 1);
            Debug.Assert(LinkedListSolutions.count(99, RecursiveLinkedList.FromRange(0, 10)) == 0);

            Debug.Assert(ArraySolutions.count(9, Enumerable.Range(0, 10).ToArray()) == 1);
            Debug.Assert(ArraySolutions.count(99, Enumerable.Range(0, 10).ToArray())  == 0);

        }

        public static void Run() {

            Console.WriteLine("\nCount (Non Tail recursive)");
            Analyse(() => EnumerableSolutions.count(99, Enumerable.Range(0, listLength)), "Enumerable");
            Analyse(() => LinkedListSolutions.count(99, RecursiveLinkedList.FromRange(0, listLength)), "LinkedList");
            Analyse(() => ArraySolutions.count(99, Enumerable.Range(0, listLength).ToArray()), "Array");

            Console.WriteLine("\nEvens");
            Analyse(() => ArraySolutions.evens(Enumerable.Range(0, listLength).ToArray()), "Array");
            Analyse(() => LinkedListSolutions.evens(RecursiveLinkedList.FromRange(0, listLength)), "LinkedList") ;
        }

        private static class EnumerableSolutions {
            public static int count(int item, IEnumerable<int> list) {
                return list.Count() == 0
                    ? 0
                    : (list.ElementAt(0) == item ? 1 : 0) + count(item, list.Skip(1));
            }
        }

        private static class LinkedListSolutions {

            public static int count(int item, LinkedList<int> list) {
                return list.Count() == 0
                    ? 0
                    : (list.First() == item ? 1 : 0) + count(item, list.Tail());
            }

            public static LinkedList<int> evens(LinkedList<int> list) {
                if (list.Count() == 0)
                    return new LinkedList<int>();
                else if (even(list.Head()))
                    return list.Head().Cons(evens(list.Tail()));
                else
                    return evens(list.Tail());
            }
        }

        private static class ArraySolutions {
            public static int count(int item, int[] list) {

                if (list.Length == 0)
                    return 0;
                else {
                    var tail = new int[list.Length - 1];
                    Array.Copy(list, 1, tail, 0, tail.Length);

                    return (list[0] == item ? 1 : 0) + count(item, tail);
                }
            }

            public static int[] evens(int[] list) {

                if (list.Length == 0)
                    return new int[0];
                else if (even(list[0])) {

                    var tail = new int[list.Length - 1];
                    Array.Copy(list, 1, tail, 0, tail.Length);

                    var evensTail = evens(tail);

                    var newList = new int[evensTail.Length + 1];

                    Array.Copy(evensTail, 0, newList, 1, evensTail.Length);

                    newList[0] = list[0];
                    return newList;
                }
                else {
                    var tail = new int[list.Length - 1];
                    Array.Copy(list, 1, tail, 0, tail.Length);

                    return evens(tail);
                }
            }
        }
    }
}
