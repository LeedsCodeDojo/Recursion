using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using RecursiveArray = Recursion_Solutions_CSharp.ArrayRecursionExtensions;
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
        private static int listLength = 10000;

        private static void OutputPeakMemory() {
            Console.WriteLine("Peak memory used: {0}Mb", GC.GetTotalMemory(true) / 1024 / 1024);
        }

        private static void OutputRemainingStack() {
            Console.WriteLine("Remaining stack space: {0}Kb", EstimatedRemainingStackBytes() / 1024);
        }

        private static void Analyse(Action recursiveProcess, string name) {
            GC.Collect();
            Thread.Sleep(100);
            var startMemory = Process.GetCurrentProcess().WorkingSet64;
            OutputRemainingStack();
            var timer = Stopwatch.StartNew();
            recursiveProcess.Invoke();
            var ms = timer.ElapsedMilliseconds;
            var usedMemory = Process.GetCurrentProcess().WorkingSet64 - startMemory;
            Console.WriteLine("{0} runs {1} iterations in {2}ms, increasing process memory by {3}Mb", name, listLength, ms, usedMemory/1024/1024);
        }

        public static void TestSolutions() {

            Console.WriteLine("Testing solutions...");

            // count (non tail recursive)
            Debug.Assert(EnumerableSolutions.count(9, Enumerable.Range(0, 10)) == 1);
            Debug.Assert(EnumerableSolutions.count(99, Enumerable.Range(0, 10)) == 0);

            Debug.Assert(LinkedListSolutions.count(9, RecursiveLinkedList.FromRange(0, 10)) == 1);
            Debug.Assert(LinkedListSolutions.count(99, RecursiveLinkedList.FromRange(0, 10)) == 0);

            Debug.Assert(ArraySolutions.count(9, RecursiveArray.FromRange(0, 10)) == 1);
            Debug.Assert(ArraySolutions.count(99, RecursiveArray.FromRange(0, 10)) == 0);

            Debug.Assert(RecursiveListSolutions.count(9, RecursiveList.FromRange(0, 10)) == 1);
            Debug.Assert(RecursiveListSolutions.count(99, RecursiveList.FromRange(0, 10)) == 0);

            // count (tail recursive)
            Debug.Assert(EnumerableSolutions.count_tail(9, Enumerable.Range(0, 10), 0) == 1);
            Debug.Assert(EnumerableSolutions.count_tail(99, Enumerable.Range(0, 10), 0) == 0);

            Debug.Assert(LinkedListSolutions.count_tail(9, RecursiveLinkedList.FromRange(0, 10), 0) == 1);
            Debug.Assert(LinkedListSolutions.count_tail(99, RecursiveLinkedList.FromRange(0, 10), 0) == 0);

            Debug.Assert(ArraySolutions.count_tail(9, RecursiveArray.FromRange(0, 10), 0) == 1);
            Debug.Assert(ArraySolutions.count_tail(99, RecursiveArray.FromRange(0, 10), 0) == 0);

            Debug.Assert(RecursiveListSolutions.count_tail(9, RecursiveList.FromRange(0, 10), 0) == 1);
            Debug.Assert(RecursiveListSolutions.count_tail(99, RecursiveList.FromRange(0, 10), 0) == 0);

            // evens
            Debug.Assert(EnumerableSolutions.evens(Enumerable.Range(0, 9)).SequenceEqual(new int[] { 0, 2, 4, 6, 8 }));
            Debug.Assert(LinkedListSolutions.evens(RecursiveLinkedList.FromRange(0, 9)).SequenceEqual(new int[] { 0, 2, 4, 6, 8 }));
            Debug.Assert(ArraySolutions.evens(RecursiveArray.FromRange(0, 9)).SequenceEqual(new int[] { 0, 2, 4, 6, 8 }));
            Debug.Assert(RecursiveListSolutions.evens(RecursiveList.FromRange(0, 9)).EqualsArray(new int[] { 0, 2, 4, 6, 8 }));

            Console.WriteLine("Tests passed");
        }

        public static void Run() {

            CollectionsRecursivePerformanceAnalysis.TestSolutions();

            Console.WriteLine("\nCount (Non Tail recursive)");
            //Analyse(() => EnumerableSolutions.count(99, Enumerable.Range(0, listLength)), "Enumerable");
            Analyse(() => LinkedListSolutions.count(99, RecursiveLinkedList.FromRange(0, listLength)), "LinkedList");
            Analyse(() => ArraySolutions.count(99, RecursiveArray.FromRange(0, listLength)), "Array");
            Analyse(() => RecursiveListSolutions.count(99, RecursiveList.FromRange(0, listLength)), "RecursiveList");

            Console.WriteLine("\nCount (Tail recursive)");
            //Analyse(() => EnumerableSolutions.count_tail(99, Enumerable.Range(0, listLength), 0), "Enumerable");
            Analyse(() => LinkedListSolutions.count_tail(99, RecursiveLinkedList.FromRange(0, listLength), 0), "LinkedList");
            Analyse(() => ArraySolutions.count_tail(99, RecursiveArray.FromRange(0, listLength), 0), "Array");
            Analyse(() => RecursiveListSolutions.count_tail(99, RecursiveList.FromRange(0, listLength), 0), "RecursiveList");

            Console.WriteLine("\nEvens");
            //Analyse(() => EnumerableSolutions.evens(Enumerable.Range(0, listLength)), "Enumerable");
            Analyse(() => LinkedListSolutions.evens(RecursiveLinkedList.FromRange(0, listLength)), "LinkedList");
            Analyse(() => ArraySolutions.evens(RecursiveArray.FromRange(0, listLength)), "Array");
            Analyse(() => RecursiveListSolutions.evens(RecursiveList.FromRange(0, listLength)), "RecursiveList");
        }

        private static class EnumerableSolutions {
            public static int count(int item, IEnumerable<int> list) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return 0;
                }
                else {
                    return (list.ElementAt(0) == item ? 1 : 0) + count(item, list.Skip(1));
                }
            }

            public static int count_tail(int item, IEnumerable<int> list, int accumulator) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return accumulator;
                }
                else {
                    return count_tail(item, list.Skip(1), accumulator + (list.ElementAt(0) == item ? 1 : 0));
                }
            }

            public static IEnumerable<int> evens(IEnumerable<int> list) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return new List<int>();
                }
                else if (even(list.ElementAt(0))) {
                    var newList = new List<int> { list.ElementAt(0) };
                    newList.AddRange(evens(list.Skip(1)));
                    return newList;
                }
                else {
                    return evens(list.Skip(1));
                }
            }
        }

        private static class LinkedListSolutions {

            public static int count(int item, LinkedList<int> list) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return 0;
                }
                else {
                    return (list.Head() == item ? 1 : 0) + count(item, list.Tail());
                }
            }

            public static int count_tail(int item, LinkedList<int> list, int accumulator) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return accumulator;
                }
                else {
                    return count_tail(item, list.Tail(), accumulator + (list.Head() == item ? 1 : 0));
                }
            }

            public static LinkedList<int> evens(LinkedList<int> list) {
                if (list.Count() == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return new LinkedList<int>();
                }
                else if (even(list.Head())) {
                    return list.Head().Cons(evens(list.Tail()));
                }
                else {
                    return evens(list.Tail());
                }
            }
        }

        private static class ArraySolutions {
            public static int count(int item, int[] list) {

                if (list.Length == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return 0;
                }
                else {
                    return (list.Head() == item ? 1 : 0) + count(item, list.Tail());
                }
            }

            public static int count_tail(int item, int[] list, int accumulator) {

                if (list.Length == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return accumulator;
                }
                else {
                    return count_tail(item, list.Tail(), accumulator + (list.Head() == item ? 1 : 0));
                }
            }

            public static int[] evens(int[] list) {

                if (list.Length == 0) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return new int[0];
                }
                else if (even(list[0])) {
                    return list.Head().Cons(evens(list.Tail()));
                }
                else {
                    return evens(list.Tail());
                }
            }
        }

        private static class RecursiveListSolutions {
            public static int count(int item, RecursiveList list) {
                if (list.IsEmpty) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return 0;
                }
                else {
                    return (list.Head == item ? 1 : 0) + count(item, list.Tail);
                }
            }

            public static int count_tail(int item, RecursiveList list, int accumulator) {
                if (list.IsEmpty) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return accumulator;
                }
                else {
                    return count_tail(item, list.Tail, accumulator + (list.Head == item ? 1 : 0));
                }
            }

            public static RecursiveList evens(RecursiveList list) {

                if (list.IsEmpty) {
                    OutputPeakMemory();
                    OutputRemainingStack();
                    return RecursiveList.Empty();
                }
                else if (even(list.Head)) {
                    return RecursiveList.Cons(list.Head, evens(list.Tail));
                }
                else {
                    return evens(list.Tail);
                }
            }
        }

        // Some methods to estimate stakc ised, from http://stackoverflow.com/questions/2901185/checking-stack-size-in-c-sharp
        private struct MEMORY_BASIC_INFORMATION {
            public uint BaseAddress;
            public uint AllocationBase;
            public uint AllocationProtect;
            public uint RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }

        private const uint STACK_RESERVED_SPACE = 4096 * 16;

        [DllImport("kernel32.dll")]
        private static extern int VirtualQuery(
            IntPtr lpAddress,
            ref MEMORY_BASIC_INFORMATION lpBuffer,
            int dwLength);

        private unsafe static uint EstimatedRemainingStackBytes() {
            MEMORY_BASIC_INFORMATION stackInfo = new MEMORY_BASIC_INFORMATION();
            IntPtr currentAddr = new IntPtr((uint)&stackInfo - 4096);

            VirtualQuery(currentAddr, ref stackInfo, sizeof(MEMORY_BASIC_INFORMATION));
            return (uint)currentAddr.ToInt64() - stackInfo.AllocationBase - STACK_RESERVED_SPACE;
        }
    }
}
