Recursion Exercises
===================

Write recursive functions to do all of the following.  For extra bonus points, do it without mutable variables.

Work on whichever problems you like.  They generally get harder, and with less of an explanation, as they go.

## 1 Basic

### 1.1 Factorial

Write a recursive function which calculates the factorial of a number, defined as:

![factorial](http://upload.wikimedia.org/math/a/9/1/a91da51a80ac8291d8dbcc4cb77c0936.png)

5! = 120

### 1.2 Fibonacci

Calclate the Nth Fibonacci number:

![fibonacci](http://upload.wikimedia.org/math/7/2/7/727f7c8fa1794d5d2d5ad828adb829c8.png)

with the first two numbers in the sequence being

![fibonacci](http://upload.wikimedia.org/math/a/9/2/a92c5f0981136ba333124cdfe6d3c3ce.png)

The start of the sequence goes:

![fib](http://upload.wikimedia.org/math/c/a/b/cabe91689f6a1af616ace02827c6e89c.png)

### 1.3 Sum a list

Sum the values in a list.

The sum of [1, 2, 3, 4, 5] is 15.

### 1.4 Count the items in a list

There are 5 items in the list [1, 2, 3, 4, 5].

### 1.5 Filter a list

Filter a list of numbers to return only the even ones.

The list [1, 2, 3, 4, 5, 6, 7, 8] when filtered should give [2, 4, 6, 8].

Note: This is much easier in languages which have a recursive list structures.  In languages which don't, such as C#, it's a bit of a pain.  You could use the RecursiveList which can be found in the repository. Or just move on to the next exercise..

### 1.6 IsEven

Write the pair of functions isEven and isOdd using Mutual Recursion.  The pseudocode for this is:

    isEven(n)
      if n is 0 then true
      else isOdd(n - 1)

    isOdd(n)
      if n is 0 then false
      else isEven(n - 1) 

## 2 Intermediate

### 2.1 Ackermann

Write the Ackermann function, defined for today's purposes as:

![ack](http://upload.wikimedia.org/math/0/a/e/0ae4053de098cc9554752b190a38bc56.png)

When called with the numbers 3 and 10, it should return 8189.  Enter much higher numbers and you could be waiting a while.

### 2.2 Directory Search

Write a function which searches all files and folders of a provided path for a file with a particular name.

### 2.3 Tail Call List Count

Try counting the items in a list again, using your previous solution (if you wrote one), but in a list containing 100,000 items.

A couple of things might happen:
1. It will be extremely slow.  This is especially likely if you're using something like C# which doesn't have a recursive data type.  See Appendix B for tips on working with lists recursively in languages like C#.
2. You might get a Stack Overflow.  (Some languages, in particula dynamic ones, don't seem to have this problem regardless).

Write the function again, this time with a tail call (e.g. using an accumulator to hold the count).  Assuming your language supports TCO, you should be able to count on the list with 100,000 items.  (If using C#, see Appendix A for details on making sure TCO is enabled).

### 2.4 Tail Call Filter

Try filtering a list with 100,000 items.  Again, this might be slow and you might get a Stack Overflow.

Write a function to filter the list of numbers to get the evens, this time with a tail call.

### 2.5 Continuations List Count

Count the items in a list again, this time using continuations.

### 2.6 Continuations Filter

Filter a list of numbers again to get the evens, with a continuation.

## 3 Advanced

### 3.1 Continuations Fibonacci

Do Fibonacci again, this time with continuations to avoid a Stack Overflow.

(Note: The 'standard' recursive solution is so slow you probably won't want to wait to find out if it's worked..)

### 3.2 Continuations Tree Search

Implement either the 'Directory search' or 'Tree Seach' again, this time with continuations so large structures can be searched.  Try creating a large structure to test it with.

### 3.3 Continuations Ackermann

Ackermann, with continuations.  Try calling it with 3 and 12 to see if it's worked.

### Appendix A - Optimising Tail Calls in C# 

While the .Net VM and C# compiler are able to optimise tail calls (to avoid Stack Overflow), it may or may not happen.  To get your tail calls optimised, make sure you:
* Compile for 64-bit (in project build settings) - 32-bit applications don't get TCO
* Turn on 'Optimize code' (in project build settings)
* Use a more recent version (apparently the optimisation is more likely on .Net 4 and above)

### Appendix B - Recursive lists in C#.

If your language doesn't have a recursive list structure, doing recursion with collections can be a pain.  Some of the problems with the built-in list structures are:
* they don't always make it easy to get the 'head' and 'tail' of a list
* Building up a list by appending items onto the front can be difficult
* Both of the above can be very inefficient

With C#, you can make your own recursive type to solve these problems:

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
    }

Filling it up, printing it and/or comparing it to other things will be your main challenges, but it is efficient and works well with recursion.  There is a copy of something similar in TFS: $/Development Repository/Code Dojos/Recursion/RecursiveList.cs

