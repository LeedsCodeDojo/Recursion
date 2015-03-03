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

text

      if n = 0 then 1
      else n * factorial (n-1)
