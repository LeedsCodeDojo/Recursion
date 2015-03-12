using System;
using System.Collections.Generic;
using RecursiveLinkedList = Recursion_Solutions_CSharp.LinkedListRecursionExtensions;

namespace Recursion_Solutions_CSharp {
    static class Program {

        static void Main(string[] args) {

            //Console.WriteLine("Collections Recursion Performance Analysis");
            //CollectionsRecursivePerformanceAnalysis.Run();

            Console.WriteLine("\nBasic Problems\n");
            Console.WriteLine("Factorial 5: {0}", BasicProblems.factorial_conditional(5));
            Console.WriteLine("Fibonacci 7: {0}", BasicProblems.fibonacci(7));
            Console.WriteLine("Sum [1..5] = {0}", BasicProblems.sum(RecursiveList.FromRange(0,6)));
            Console.WriteLine("Count 1 [1,2,1,3,4,1] = {0}", BasicProblems.count(1, RecursiveList.FromArray(new int[] { 1, 2, 1, 3, 4, 1 })));
            Console.Write("Evens [1..8] = "); BasicProblems.evens(RecursiveList.FromRange(1, 9)).Print();
            Console.WriteLine("\n99 even? {0} 21 odd? {1}", BasicProblems.isEven(99), BasicProblems.isOdd(21));

            Console.WriteLine("\nIntermediate Problems\n");
            Console.WriteLine("Ackermann 3 10: {0}", IntermediateProblems.ackermann(3, 10));
            Console.WriteLine("treesearch c:temp {0}", IntermediateProblems.treesearch("thefile.txt", @"c:\temp"));
            Console.WriteLine("Count (tail) 99 [1..10] = {0}", IntermediateProblems.count_tail(99, RecursiveList.FromRange(0, 10), 0)); // no TCO
            Console.Write("Evens (tail) [1..10] = "); IntermediateProblems.evens_tail(RecursiveList.FromRange(0, 10), RecursiveList.Empty()).Print();
            IntermediateProblems.count_continuation(4, RecursiveList.FromRange(0, 10), (result => Console.WriteLine("\nCount (continuation) 4 [1..10] = {0}", result)));
        }
    }
}
