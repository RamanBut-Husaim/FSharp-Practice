module Chapter04.Exercises.Exercise07

let rec multiplicity x xs =
    match xs with
    | [] -> 0
    | t :: xs ->
        let count = multiplicity x xs
        if t = x then (count + 1)
        else count
