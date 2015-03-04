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

![fibonacci](http://upload.wikimedia.org/math/4/3/d/43d30dc03ffec0a82d4471f1009ef519.png)

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

Note: This is much easier in languages which have a recursive list structures.  In other languages, such as C#, it's a bit of a pain.  You could try using a Linked List. Or just move on to the next exercise..

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

If your language makes this difficult, move onto the next exercise, which is similar.  And stop using Haskell.

### 2.3 Tree Search

Write a function which searches a tree-like data structure for a given item.

If your language supports a recursive list structure, this will do, as the head and tail can be considered the two branches of the tree, e.g. Scheme:

    (treesearch 9 '(((9)) 2 (3) (4 5 (6 (7)) 8)))

Alternatively you could write yourself some kind of tree structure and use that:

    type Tree =
    | Branch of string * Tree list
    | Leaf of string
    
    let tree = Branch ("a", [Branch ("b", [Leaf "c"; Leaf "d"]); Branch ("e", [Leaf "f"; Leaf "g"])])

If that all seems like too much work in your language, just move along.  And learn yourself a decent language!

### 2.4 Tail Call List Count

Try counting the items in a list again, using your previous solution (if you wrote one), but in a list containing 100,000 items.

A couple of things might happen:
1. It will be extremely slow.  This is especially likely if you're using something like C# which doesn't have a recursive data type.  In that situation, try writing it with a LinkedList instead.  (This should make getting at the 'first' element and the 'remaining' elements much quicker, which you generally want to do with recursion).
2. You might get a Stack Overflow.  (Some languages, in particula dynamic ones, don't seem to have this problem regardless).

Write the function again, this time with a tail call (e.g. using an accumulator to hold the count).  Assuming your language supports TCO, you should be able to count on the list with 100,000 items.

### 2.5 Tail Call Filter

Filter another list of numbers to get the evens, this time with a tail call.  Again, try it with a list of around 100,000 items.

### 2.6 Continuations List Count

Count the items in a list again, this time using continuations.

### 2.7 Continuations Filter

Filter a list of numbers again to get the evens, with a continuation.

## 3 Advanced

### 3.1 Continuations Fibonacci

Do Fibonacci again, this time with continuations to avoid a Stack Overflow.

(Note: The 'standard' recursive solution is so slow you probably won't want to wait to find out if it's worked..)

### 3.2 Continuations Tree Search

Implement either the 'Directory search' or 'Tree Seach' again, this time with continuations so large structures can be searched.  Try creating a large structure to test it with.

### 3.3 Continuations Ackermann

Ackermann, with continuations.  Try calling it with 3 and 12 to see if it's worked.

### 3.4 Towers of Hannoi

Go and solve the [Towers of Hannoi puzzle](https://www.learneroo.com/modules/71/nodes/402) using recursion.

### 3.5 Permutations

Output all permutations of a passed string (or list of characters).

### Appendix A - Tips for working with lists in C# and similar languages.

If your language doesn't have a recursive list structure, doing recursion with collections can be a pain.  The best way I've found to do it so far is to use a LinkedList.  This is a PITA to work with, but at least lets you het the 'head' and 'tail' of the list pretty quickly.

To save you a bit of time, here's a function which works through a list of integers and doubles every item, including a couple of helper functions to make working with LinkedLists easier:


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

    // Recursively builds up a list by doubling everything in the passed list
    static LinkedList<int> double_everything(LinkedList<int> list) {
        if (list.Count() == 0)
            return new LinkedList<int>();
        else
            return Cons(Head(list)*2, Tail(list));
    }

    Console.WriteLine(double_everything(LinkedListRange(1, 10)).print());
