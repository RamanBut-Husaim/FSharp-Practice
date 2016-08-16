module Chapter04.Exercises.Exercise13

let findSmallest elements =
    let rec findInternal minElement els =
        match els with
        | [] -> minElement
        | x :: xs ->
            if x < minElement then findInternal x xs
            else findInternal minElement xs
    findInternal System.Int32.MaxValue elements

let rec delete (value, elements) =
    match elements with
    | [] -> []
    | x :: xs ->
        if x = value then xs
        else
            let rest = delete (value, xs)
            x :: rest

let rec bruteSort elements =
    match elements with
    | [] -> []
    | xs ->
        let smallest = findSmallest xs
        let rest = delete (smallest, xs)
        let sorted = bruteSort rest
        smallest :: sorted
