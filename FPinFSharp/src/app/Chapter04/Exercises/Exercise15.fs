module Chapter04.Exercises.Exercise15

let rec revrev elements =
    match elements with
    | [] -> []
    | x :: xs ->
        let rest = revrev xs
        let reversedList = List.rev x
        rest @ [reversedList]