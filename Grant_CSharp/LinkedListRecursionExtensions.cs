using System.Collections.Generic;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Extensions and helper methods to make working with a LinkedList easier when doing recursion.
    /// Only workrs for LInkedList<int>.
    /// </summary>
    public static class LinkedListRecursionExtensions {
        // Head gets the first item
        public static int Head(this LinkedList<int> list) {
            return list.First.Value;
        }

        // Tail gets the whole list excliding the first item.  It is slow.
        public static LinkedList<int> Tail(this LinkedList<int> list) {
            var copy = new LinkedList<int>(list.ToList());
            copy.RemoveFirst();
            return copy;
        }

        // Attaches the item onto the beginning of the list
        public static LinkedList<int> Cons(this int head, LinkedList<int> tail) {
            tail.AddFirst(head);
            return tail;
        }

        // Creates a LinkedList from a range of integers, one element per number
        public static LinkedList<int> FromRange(int from, int to) {
            return new LinkedList<int>(Enumerable.Range(from, to));
        }

        // Prints each item of a linked list
        public static string print(this LinkedList<int> list) {
            return list.Aggregate("", (output, item) => output + "," + item);
        }

        // Example - recursively builds up a list by doubling everything in the passed list
        static LinkedList<int> double_everything(LinkedList<int> list) {
            if (list.Count() == 0)
                return new LinkedList<int>();
            else
                return (list.Head() * 2).Cons(double_everything(list.Tail()));
        }
    }
}
