module Chapter04.Exercises.Exercise08

let rec splitInternal elements switch = 
    match elements with
    | [] -> ([], [])
    | x :: xs -> 
        let (odd, even) = splitInternal xs (not switch)
        if switch then (x :: odd, even)
        else (odd, x :: even)

let split elements = splitInternal elements true
