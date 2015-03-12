
using System;
namespace Recursion_Solutions_CSharp {
    public class RecursiveList {

        private readonly int? _head;
        private readonly RecursiveList _tail;

        private RecursiveList(int? head, RecursiveList tail) {
            _head = head;
            _tail = tail;
        }

        public int Head { get {
            if (this.IsEmpty)
                throw new InvalidOperationException("Cannot read Head of an empty list");

            return _head.Value; 
        } }


        public RecursiveList Tail { get { return _tail; } }
        public bool IsEmpty { get { return !_head.HasValue; } }

        public static RecursiveList Cons(int head, RecursiveList tail) {
            return new RecursiveList(head, tail);
        }

        public static RecursiveList Empty() {
            return new RecursiveList(null, null);
        }

        public static RecursiveList FromRange(int from, int to) {
            if (from >= to) 
                return RecursiveList.Empty();
            else
                return new RecursiveList(from, RecursiveList.FromRange(++from, to));
        }

        public static RecursiveList FromArray(int[] array) {
            if (array.Length == 0)
                return RecursiveList.Empty();
            else
                return new RecursiveList(array[0], RecursiveList.FromArray(array.Tail()));
        }

        public void Print() {
            if (!this.IsEmpty) {
                Console.Write(this.Head + ", ");
                this.Tail.Print();
            }
        }

        public bool EqualsArray(int[] array) {
            if (this.IsEmpty && array.Length == 0)
                return true;
            else if (this.Head == array[0])
                return this.Tail.EqualsArray(array.Tail());
            else
                return false;
        }
    }
}
