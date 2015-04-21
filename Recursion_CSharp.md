Recursion
=========

Some details about recursive functions, with examples mainly in C#.

## Definition

Recursion is "The repeated application of a recursive procedure or definition".  In simple, practical terms it's a function which calls itself:

    int factorial(int n) {
        if( n == 0 )
            return 1;
        else
            return n * factorial(n - 1);
    }

## Structure of a Recursive Function

Function definition:

    int factorial(int n)

Base Case:

    if( n == 0 )
        return 1;

Also known as the Terminal Case.  This is when the recursion stops.

Recursive Case:

    else
        return n * factorial(n - 1);

Where the recursion happens.  The function should be called with parameter(s) which move it towards the Base Case.

## Examples in Other Languages
        
### C# (using conditional operator)

    static int factorial(int n) {
        return n == 0
            ? 1
            : n * factorial(n - 1);
    }

### F# (using ifs)

    let rec factorial n =
      if n = 0 then 1
      else n * factorial (n-1)
    
### F# (using pattern matching)

    let rec factorial = function
      | 0 -> 1
      | n -> n * factorial (n-1)
      
### Scheme

    (define (factorial n)
      (cond 
        ((eq? n 0) 1)
        (else (* n (factorial (- n 1))))))

## Types of Recursion

### Single recursion

The function is called once:

    int factorial(int n) {
        if( n == 0 )
            return 1;
        else
            return n * factorial(n - 1);
    }

### Multiple Recursion

The function is called multiple times:

    int lucas(int n) {
        if( n == 0 )
            return 2;
        if( n == 1 )
            return 1;
        else
            return lucas(n - 1) + lucas(n - 2);
    }

### Mutual Recursion

Two functions which call each other:

    int even(int n) {
        if( n == 0 )
            return true;
        else
            return odd(n - 1);
    }
    
    int odd(int n) {
        if( n == 0 )
            return false;
        else
            return even(n - 1);
    }

## Tail Call Optimisation

Each time the function is called recursively it uses up a frame on the stack.  There are a limited number of frames available (often around 64,000) and when they run out you get a Stack Overflow:

    int sum(List<int> list) {
        return list.Count == 0
            ? 0
            : list[0] + sum(list.Skip(1));
    }

    > sum_recursive [1..60000];;
    val it : int = 1800030000
    
    > sum_recursive [1..65000];;
    Process is terminated due to StackOverflowException.
    
If you write the function in such a way that it does not need to be kept on the stack, by doing a Tail Call, some compilers recognise this and optimise the recursive call so only one stack frame is used:

    int sum_tail(RecursiveList list, int accumulator) {
        if (list.Count == 0) 
            return accumulator;
        else
            return sum_tail(list.Skip(1), accumulator + list[0]);
    }

    > sum_tail [1..65000] 0;;
    val it : int = 2112532500

The most common way to do this is to pass an accumulator to the function, so when the Base Case is reached it has everything it needs, and doesn't need to work back up the stack.

### Note regarding TCO in C#  

While the CLR supports tail calls (unlike for example the JVM), the C# compiler may or may not optimise them.  To try and make it happen:
* Compile for 64 bit
* Turn on optimisations

F# always optimises tail calls.  Other languages vary.

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
