using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Solutions to the Intermediate problems
    /// </summary>
    public static class IntermediateProblems {
        public static bool even(int num) { return num % 2 == 0; }

        public static int ackermann(int m, int n) {
            if (m == 0)
                return n + 1;
            else if (n == 0)
                return ackermann(m - 1, 1);
            else
                return ackermann(m - 1, ackermann(m, n - 1));
        }

        public static bool treesearch(string filename, string path) {
            var filesFolders = new DirectoryInfo(path).EnumerateFileSystemInfos();

            if (filesFolders.Where(info => info.Name == filename).Count() > 0)
                return true;

            return filesFolders
                .Where(info => info is DirectoryInfo)
                .Any(directory => treesearch(filename, directory.FullName));
        }

        // This is not tail optimised for some reason.
        public static int count_tail(int item, LinkedList<int> list, int count) {
            if (list.Count() == 0)
                return count;
            else
                return count_tail(item, list.Tail(), count + (list.Head() == item ? 1 : 0));
        }

        public static LinkedList<int> evens_tail(LinkedList<int> list, LinkedList<int> accumulator) {
            if (list.Count() <= 0)
                return accumulator;
            else if (even(list.Head()))
                return evens_tail(list.Tail(), list.Head().Cons(accumulator));
            else
                return evens_tail(list.Tail(), accumulator);
        }

        public static void count_continuation(int item, LinkedList<int> list, Action<int> continuation) {
            if (list.Count() == 0)
                continuation.Invoke(0);
            else
                count_continuation(item, list.Tail(), (result =>
                    continuation.Invoke(result + (list.Head() == item ? 1 : 0))));
        }
    }
}
