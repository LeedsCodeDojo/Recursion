Recursion
=========

Some details about recursive functions.  Examples mainly in F#.

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

    let rec lucas n =
      if n = 0 then 2
      elif n = 1 then 1
      else lucas (n-1) + lucas (n-2)

### Mutual Recursion

Two functions which call each other:

    let rec even number =  
      if number = 0 then true
      else odd (number-1)
    and odd number = 
      if number = 0 then false
      else even (number-1)

(In F#, because of the single-pass compilation, you need to specify mutually recursive functions together with 'and'). 

## Tail Call Optimisation

Each time the function is called recursively it uses up a frame on the stack.  There are a limited number of frames available (often around 64,000) and when they run out you get a Stack Overflow:

    let rec sum_recursive list =
      if (empty list) then 0
      else list.[0] + sum_recursive (tail list)

    > sum_recursive [1..60000];;
    val it : int = 1800030000
    
    > sum_recursive [1..65000];;
    Process is terminated due to StackOverflowException.
    
If you write the function in such a way that it does not need to be kept on the stack, by doing a Tail Call, some compilers recognise this and optimise the recursive call so only one stack frame is used:

    let rec sum_tail list accumulator =
      if (empty list) then accumulator
      else sum_tail (tail list) (accumulator + list.[0])
      
    > sum_tail [1..65000] 0;;
    val it : int = 2112532500

The most common way to do this is to pass an accumulator to the function, so when the Base Case is reached it has everything it needs, and doesn't need to work back up the stack.

Some languages which support Tail Call Optimisation:
* F#
* Scheme
* Erlang
* C# (when compiled for 64 bit)
* Haskell (optionally)
* Scala (for self-calls)
* Some Ruby implementations

Some languages which don't:
* Python
* C# (compiled for 32 bit)
* Java
* Clojure
* Javascript
* Most Ruby implementations

(Note: For VM-based languaged that run on things like the JVM or CLR, the compiler can optimise some tail calls, but for full TCO it has to be supported at the VM level.  The CLR supports this while the JVM does not).

(Another Note: Some languages which don't support TCO use something called Trampolining instead, which does something crazy with lambdas.  See The Internet for details.)

## Continuations

One fairly advanced programming technique involves passing one or more functions to the function doing the work so that instead of returning a value, the function calls one of the passed functions with the result:

    let rec sum_continuation list collector =
      if (empty list) then collector 0
      else 
        sum_continuation 
          (tail list) 
          (fun sum -> collector (sum + list.[0]))
    
    sum_continuations [1..5] (fun sum ->
      printfn "Answer: %i" sum)

There is in fact an entire style of programming called 'Continuation Passing Style' (CPS) in which everything is written in this way, which was surely thought up by a sadist.

This is important in relation to recursion because sometimes a recursive call cannot be made Tail Recursve using the normal mechanism, such as Multiple Recursive calls.  In these cases, continuations can be used to make the function Tail Recursive.  It can get rather complicated.

This continuation-based Scheme function finds the maximum depth of a tree, which can't be optimised in the normal way as the function has to be called recursively on each branch of the tree:

    (define maxdepth*&co
      (lambda (l col)
        (cond
          ((null? l) (col 1))
          ((atom? (car l)) 
            (maxdepth*&co (cdr l)
                          (lambda (n) (col n))))
          (else 
            (maxdepth*&co (car l)
                          (lambda (ncar) 
                            (maxdepth*&co (cdr l) 
                                          (lambda (ncdr) 
                                            (col 
                                              (cond
                                                ((> (add1 ncar) ncdr) (add1 ncar))
                                                (else ncdr)))))))))))

Those brave enough to give it a read might notice that the second time 'maxdepth&co' is called, it's passed a lambda which gets the result from one branch of the tree, which in turn calls the function *again*, passing a *second* lambda which gets the results from the other branch.

The rest of you will just have to take my word for it. ;-)
