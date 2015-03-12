using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Extensions and helper methods to make working with Arrays easier when doing recursion.
    /// Only workrs for arrays of int.
    /// </summary>
    public static class ArrayRecursionExtensions {
        // Head gets the first item
        public static int Head(this int[] list) {
            return list[0];
        }

        // Tail gets the whole list excliding the first item.
        public static int[] Tail(this int[] list) {
            var tail = new int[list.Length - 1];
            Array.Copy(list, 1, tail, 0, tail.Length);
            return tail;
        }

        // Attaches the item onto the beginning of the list
        public static int[] Cons(this int head, int[] tail) {
            var newList = new int[tail.Length + 1];
            Array.Copy(tail, 0, newList, 1, tail.Length);
            newList[0] = head;
            return newList;
        }

        // Creates an array from a range of integers, one element per number
        public static int[] FromRange(int from, int to) {
            return Enumerable.Range(from, to).ToArray();
        }

        // Prints each item of a linked list
        public static string print(this int[] list) {
            return list.Aggregate("", (output, item) => output + "," + item);
        }
    }
}
