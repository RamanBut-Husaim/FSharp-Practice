module Chapter04.Exercises.Exercise11

let rec isWeaklyAscending elements = 
    match elements with
    | [] -> true
    | [ x ] -> true
    | x1 :: x2 :: xs -> 
        let other = isWeaklyAscending xs
        (x1 <= x2) && other

let rec count pair = 
    match pair with
    | ([], x) -> 0
    | (x :: xs, y) when x > y -> 0
    | (x :: xs, y) -> 
        let rest = count (xs, y)
        if (x = y) then (rest + 1)
        else rest

let rec insert elements value = 
    match elements with
    | [] -> [ value ]
    | x :: xs when x <= value -> 
        let rest = insert xs value
        x :: rest
    | x :: xs when x > value -> value :: x :: xs
    | xs -> xs