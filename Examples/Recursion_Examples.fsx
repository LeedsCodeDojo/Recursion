// Examples of recursion as used in the slides
// http://prezi.com/opt1h-r7x-uy/?utm_campaign=share&utm_medium=copy

let empty = List.isEmpty
let tail = List.tail

open Checked

let rec factorial n =
    if n = 0 then 1
    else n * factorial (n-1)

let factorial_iter n =
    let mutable total = 1
    for number in [1..n] do
        total <- total * number
    total

let sum_loop list =
    let mutable total = 0
    for number in list do
        total <- total + number
    total

let rec lucas n =
    if n = 0 then 2
    elif n = 1 then 1
    else lucas (n-1) + lucas (n-2)

let rec even number =  
    if number = 0 then true
    else odd (number-1)
and odd number = 
    if number = 0 then false
    else even (number-1)

let rec sum_recursive list =
    if (empty list) then 0
    else list.[0] + sum_recursive (tail list)

let rec sum_tail list accumulator =
    if (empty list) then accumulator
    else sum_tail (tail list) (accumulator + list.[0])

let rec sum_continuation list collector =
    if (empty list) then collector 0
    else 
        sum_continuation 
            (tail list) 
            (fun sum -> collector (sum + list.[0]))
