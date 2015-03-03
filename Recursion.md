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

# Single recursion

The function is called once:

# Multiple Recursion

The function is called multiple times:

# Mutual Recursion

Two functions which call each other:

