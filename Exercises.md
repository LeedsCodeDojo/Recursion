Recursion Exercises
===================

Write recursive functions to do all of the following.  For extra bonus points, do it without mutable variables.

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

'nuff said!

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

When called with the numbers 3 and 10, it should return 8189.  Enter much higher numbers and you could be waiting a while.  (On a related note, depending on how you've written it, calling it with 3 and 12 might tell you if your language/compiler supports Tail Call Optimisation).

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

If that all seems like too much work in your language, just move along.  And learn yourself a decent language!

### 2.4 Tail Call List Count

Count the items in a list again, this time with a tail call.  Assuming your language supports TCO, you should be able to count a list with 100,000 items.

## 3 Advanced

### 3.1 Towers of Hannoi

Go and solve [this Towers of Hannoi puzzle](https://www.learneroo.com/modules/71/nodes/402) using recursion.

