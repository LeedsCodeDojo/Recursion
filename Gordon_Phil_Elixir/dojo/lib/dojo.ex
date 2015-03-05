defmodule Dojo do
 
  def factorial(0) do
    1
  end
  def factorial(number) do
    number * (factorial(number - 1))
  end

  def fibonacci(0) do
    0
  end
  def fibonacci(1) do
    1
  end
  def fibonacci(number) do
    fibonacci(number - 1) + fibonacci(number - 2)
  end

  @doc """
    Set an accumulator default value of 0
  """
  def sum(list, acc \\ 0)
  def sum([], acc) do
    acc
  end
  def sum([head|tail], acc) do
    sum(tail, acc + head)
  end

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


  def ackermann(0, n) do
    n + 1
  end
  def ackermann(m, 0) when m > 0 do
    ackermann(m-1, 1)
  end
  def ackermann(m, n) when m > 0 and n > 0 do
    ackermann(m-1, ackermann(m, n-1))
  end

  def treesearch(_searchnum, []) do
    false
  end
  def treesearch(searchnum, [head|tail]) when is_list(head) do
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

  def count(list, acc \\ 0)
  def count([], acc) do
    acc
  end
  def count([_head|tail], acc) do
    count(tail, acc + 1)
  end
end
