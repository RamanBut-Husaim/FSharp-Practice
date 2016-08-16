module Chapter04.Exercises.Exercise06

let isEven number = number % 2 = 0

let rec rmeven elements =
    match elements with
    | [] -> []
    | x :: xs ->
        let rest = rmeven xs
        if isEven x then rest
        else x :: rest