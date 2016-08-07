module Chapter04.Exercises.Exercise05

let isOdd number = number % 2 <> 0

let rec rmoddInternal index elements =
    match elements with
    | [] -> []
    | x :: xs -> 
        let rest = rmoddInternal (index + 1) xs
        if isOdd x then rest
        else x :: rest

let rmodd elements = rmoddInternal 0 elements