module Chapter04.Exercises.Exercise09

let rec zipInternal elements = 
    match elements with
    | ([], []) -> []
    | (x :: xs1, y :: ys1) -> 
        let rest = zipInternal (xs1, ys1)
        (x, y) :: rest
    | (_, _) -> failwith "the lists are not of equal length"

let zip elements = 
    let (xs, ys) = elements
    if (List.length xs) <> (List.length ys) then failwith "the lists are not of equal length"
    else zipInternal elements
