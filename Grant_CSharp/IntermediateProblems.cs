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
        public static int count_tail(int item, RecursiveList list, int accumulator) {
            if (list.IsEmpty) 
                return accumulator;
            else
                return count_tail(item, list.Tail, accumulator + (list.Head == item ? 1 : 0));
        }

        public static RecursiveList evens_tail(RecursiveList list, RecursiveList accumulator) {

            if (list.IsEmpty)
                return accumulator;
            else if (even(list.Head))
                return evens_tail(list.Tail, RecursiveList.Cons(list.Head, accumulator));
            else
                return evens_tail(list.Tail, accumulator);
        }

        public static void count_continuation(int item, RecursiveList list, Action<int> continuation) {
            if (list.IsEmpty)
                continuation.Invoke(0);
            else
                count_continuation(item, list.Tail, (result =>
                    continuation.Invoke(result + (list.Head == item ? 1 : 0))));
        }

        public static void evens_continuation(RecursiveList list, Action<RecursiveList> continuation) {
            if (list.IsEmpty) {
                continuation.Invoke(RecursiveList.Empty());
            }
            else {
                evens_continuation(list.Tail, (result => {
                    var accumulator =
                        even(list.Head)
                        ? RecursiveList.Cons(list.Head, result)
                        : result;

                    continuation.Invoke(accumulator);
                }));
            }
        }
    }
}
