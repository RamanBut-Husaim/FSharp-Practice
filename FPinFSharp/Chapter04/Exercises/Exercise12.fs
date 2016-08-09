module Chapter04.Exercises.Exercise12

let rec sum (p, elements) = 
    match elements with
    | [] -> 0
    | x :: xs -> 
        let rest = sum (p, xs)
        if p x then (x + rest)
        else rest