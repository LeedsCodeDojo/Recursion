let rec factorial = function
        | 0 -> 1
        | n -> factorial(n - 1) * n

let rec fibonacci = function
        | 0 | 1 -> 1
        | n -> fibonacci (n - 1) + fibonacci (n - 2)

let rec sum = function
        | [] -> 0
        | h::t -> h + sum t

let rec count = function
        | [] -> 0
        | _::t -> 1 + count t

let rec filter = function
        | [] -> []
        | h::t when h % 2 = 0 -> h::filter t
        | _::t -> filter t

let rec isEven = function
        | 0 -> true
        | n -> isOdd (n - 1)
and isOdd = function
        | 0 -> false
        | n -> isEven (n - 1)

let rec ackermann m n =
    match m, n with
        | 0, _ -> n + 1
        | m, 0 when m > 0 -> ackermann (m - 1) 1
        | m, n -> ackermann (m - 1) (ackermann m (n - 1))

type Tree =
    | Branch of string * Tree list
    | Leaf of string

let treeSearch tree search =
    let rec searchInTrees = function
            | Branch(b, _)::_ when b = search -> true
            | Leaf(l)::_ when l = search -> true
            | Branch(_, leaves)::t -> searchInTrees leaves || searchInTrees t
            | _::t -> searchInTrees t
            | [] -> false

    searchInTrees [tree]

let rec count_tail list acc =
    match list with
        | [] -> acc
        | _::t -> count_tail t (acc + 1)

let rec filter_tail list acc =
    match list with
        | [] -> acc
        | h::t when h % 2 = 0 -> filter_tail t (h::acc)
        | _::t -> filter_tail t acc

let rec count_cont list func =
    match list with
        | [] -> func 0
        | _::t -> count_cont t (fun count -> func (count + 1))

let rec filter_cont list func =
    match list with
        | [] -> func []
        | h::t when h % 2 = 0 -> filter_cont t (fun filtered -> func (h::filtered))
        | _::t -> filter_cont t (fun filtered -> func filtered)

let rec fibonacci_cont num func =
    match num with
        | 0 | 1 -> func 1
        | n -> fibonacci_cont (n - 1) (fun x -> fibonacci_cont (n - 2) (fun y -> func (x + y)))

let treeSearch_cont tree search func =
    let rec searchInTrees tr f =
        match tr with
            | Branch(b, _)::_ when b = search -> f true
            | Leaf(l)::_ when l = search -> f true
            | Branch(_, leaves)::t -> searchInTrees leaves (fun x -> searchInTrees t (fun y -> f (x || y)))
            | _::t -> searchInTrees t (fun x -> f x)
            | [] -> f false

    searchInTrees [tree] func 

let rec ackermann_cont m n func =
    match m, n with
        | 0, _ -> func (n + 1)
        | m, 0 when m > 0 -> ackermann_cont (m - 1) 1 (fun a -> func a)
        | m, n -> ackermann_cont m (n - 1) (fun x -> ackermann_cont (m - 1) x func)

let rec hanoi height source destination temp =
    match height with
        | 1 -> printf "%s to %s.\n" source destination
        | n -> hanoi (n - 1) source temp destination
               printf "%s to %s\n" source destination
               hanoi (n - 1) temp destination source

hanoi 9 "Tower 1" "Tower 3" "Tower 2"



