module Chapter04.Exercises.Exercise13

let findSmallest elements =
    let rec findInternal minElement els =
        match els with
        | [] -> minElement
        | x :: xs ->
            if x < minElement then findInternal x xs
            else findInternal minElement xs
    
    findInternal System.Int32.MaxValue elements
