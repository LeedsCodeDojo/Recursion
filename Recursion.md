Recursion
=========

## Definition

Recursion is "The repeated application of a recursive procedure or definition".  In simple, practical terms it's a function which calls itself:

    let rec factorial n =
      if n = 0 then 1
      else n * factorial (n-1)

## Structure of a Recursive Function

Function definition:

    let rec factorial n =

All common languages support recursive function calls.  In some, such as F#, you have to specify it explicitly.

Base Case:

      if n = 0 then 1

Also known as the Terminal Case.  This is when the recursion stops.

Recursive Case:

      else n * factorial (n-1)

Where the recursion happens.  The function should be called with parameter(s) which move it towards the Base Case.

## Types of Recursion

### Single recursion

The function is called once:

    let rec factorial n =
      if n = 0 then 1
      else n * factorial (n-1)

### Multiple Recursion

The function is called multiple times:



### Mutual Recursion

Two functions which call each other:

## Tail Calls

Each time the function is called recursively it uses up a frame on the stack.  There are a limited number of frames available (often around 64,000) and when they run out you get a Stack Overflow:

    let rec sum_recursive list =
      if (empty list) then 0
      else list.[0] + sum_recursive (tail list)

    > sum_recursive [1..60000];;
    val it : int = 1800030000
    
    > sum_recursive [1..65000];;
    Process is terminated due to StackOverflowException.
    
    
