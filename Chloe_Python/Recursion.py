def factorial(n):
    if n == 0:
        return 1
    else:
        return factorial (n - 1) * n

def fibonacci(n):
    if n == 0:
        return 0
    elif n == 1:
        return 1 
    else:
        return fibonacci (n - 1) + fibonacci(n - 2)


def sum(list):
    if not list:
        return 0 
    else:
        return list[0] + sum(list[1:])

def count(list):
    if not list:
        return 0 
    else:
        return 1 + count(list[1:])

def filter(list):
    if not list:
        return []
    elif list[0] % 2 == 0:
        return [list[0]] + filter (list[1:])
    else:
        return [] + filter (list[1:])

def isEven(n):
    if n == 0:
        return True
    else: 
        return isOdd(n-1)

def isOdd(n):
    if n==0:
        return False
    else:
        return isEven (n-1)

def ackermann(m,n):
    if m == 0:
        return n + 1
    elif m > 0 and n == 0:
        return ackermann(m - 1,1)
    elif m > 0 and n > 0:
        return ackermann(m - 1,ackermann(m,n - 1))

def count_tail(list, acc):
    if not list:
        return acc
    else:
        return count_tail(list[1:], acc + 1)


