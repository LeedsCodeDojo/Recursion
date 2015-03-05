Dojo
====

A 'mix' generated project for the Recursion dojo.

Generated with:
    mix new dojo

The main source is in `lib/dojo.ex`

Usage
-----

If you want to muck about in the shell, run it from this
directory:

```
[snapper dojo]$ iex -S mix
Erlang/OTP 17 [erts-6.3] [source] [64-bit] [smp:2:2] [async-threads:10] [hipe] [kernel-poll:false]

lib/dojo.ex:1: warning: redefining module Dojo
Compiled lib/dojo.ex
Generated dojo.app
Interactive Elixir (1.0.3) - press Ctrl+C to exit (type h() ENTER for help)
iex(1)> Dojo.sum([1,2,3])
6
iex(2)> 
```

Doctests
--------

It seems that you can add tests as part of the documentation.
I really like it (thanks for getting me to check it out, Craig and Chris),
the example is exactly what you'd type into the `iex` shell.

For example, if you document a function such as:

```elixir
@doc ~S"""
1.1 Factorial
Compute the factorial of n.

## Example:

    iex> Dojo.factorial(5)
    120

"""
def factorial(0) do
  1
end
def factorial(number) do
  number * (factorial(number - 1))
end
```

.. then add doctests to your test file:

```
[snapper dojo]$ more test/dojo_test.exs 
defmodule DojoTest do
  use ExUnit.Case, async: true
  doctest Dojo
end
```

.. then you can run your tests with `mix test`

```
[snapper dojo]$ mix test
............

Finished in 3.2 seconds (0.4s on load, 2.8s on tests)
12 tests, 0 failures

Randomized with seed 200535
```

That deserves a Jazz Club; "Nice!".
https://www.youtube.com/watch?v=fAjRmHPiESc
