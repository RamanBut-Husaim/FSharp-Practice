module Chapter04.Exercises.Exercise14

let findSmallest elements =
    let rec findInternal minElement els =
        match els with
        | [] -> Some minElement
        | x :: xs ->
            if x < minElement then findInternal x xs
            else findInternal minElement xs
    if List.isEmpty elements then None
    else findInternal System.Int32.MaxValue elements
