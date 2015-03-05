defmodule Dojo do

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



  @doc ~S"""
  1.2 Fibonacci

  Calculate the Nth Fibonacci number.

  ## Example

      iex> Dojo.fibonacci(6)
      8

      iex> Dojo.fibonacci(0)
      0

      iex> Dojo.fibonacci(8)
      21

  """
  def fibonacci(0) do
    0
  end
  def fibonacci(1) do
    1
  end
  def fibonacci(number) do
    fibonacci(number - 1) + fibonacci(number - 2)
  end

  @doc ~S"""
  1.3 Sum a list

  We can set the accumulator default value with '\\'.
  It just means that we don't have to expose another function to
  set the default.  Not sure if that's a good thing or not.
  I guess you could add this to a previously calculated value this way.

  ## Example

      iex> Dojo.sum([1,2,3,4,5])
      15

  """
  def sum(list, acc \\ 0)
  def sum([], acc) do
    acc
  end
  def sum([head|tail], acc) do
    sum(tail, acc + head)
  end



  @doc ~S"""
  1.3 Count the items in a list

      iex> Dojo.count([1,2,3,4,5])
      5

  """
  def count(list, acc \\ 0)
  def count([], acc) do
    acc
  end
  def count([_head|tail], acc) do
    count(tail, acc + 1)
  end



  @doc ~S"""
  1.4 Filter a list

  Filter a list of numbers to return only the even ones.

  ## Example

      iex> Dojo.even([1,2,3,4,5,6,7,8])  
      [2, 4, 6, 8]

  """
  def even(list, acc \\ [])
  def even([], acc) do
    Enum.reverse acc
  end
  def even([head|tail], acc) when rem(head, 2) == 0 do
    even(tail, [head|acc])
  end
  def even([_head|tail], acc) do
    even(tail, acc)
  end



  @doc ~S"""
  1.6 IsEven

  Write the pair of functions isEven and isOdd using Mutual Recursion.

  ## Example

      iex> Dojo.is_even(5)                
      false

      iex> Dojo.is_even(8)
      true

      iex> Dojo.is_odd(13)
      true

  """
  def is_even(0) do
    true
  end
  def is_even(num) do
    is_odd(num - 1)
  end

  def is_odd(0) do
    false
  end
  def is_odd(num) do
    is_even(num - 1)
  end



  @doc ~S"""
  2.1 Ackermann

  When called with the numbers 3 and 10, it should return 8189.

      iex> Dojo.ackermann(3,10)
      8189

  """
  def ackermann(0, n) do
    n + 1
  end
  def ackermann(m, 0) when m > 0 do
    ackermann(m-1, 1)
  end
  def ackermann(m, n) when m > 0 and n > 0 do
    ackermann(m-1, ackermann(m, n-1))
  end


  
  @doc ~S"""
  2.3 Tree Search

  Write a function which searches a tree-like data structure for a given item.

  ## Example

      iex> Dojo.treesearch(2, [[5,6,3,4],[3,5,6,[1,2,3]]])
      true

  """
  def treesearch(_searchnum, []) do
    # We've reached the end and didn't find it.
    false
  end
  def treesearch(searchnum, [head|tail]) when is_list(head) do
    # If the head of this list is another list, either it was the last
    # element and we've found it or we have to go round again.
    if treesearch(searchnum, head) do
      true
    else
      treesearch(searchnum, tail)
    end
  end
  def treesearch(searchnum, [head|tail]) do
    if head == searchnum do
      true
    else
      treesearch(searchnum, tail)
    end
  end

end
