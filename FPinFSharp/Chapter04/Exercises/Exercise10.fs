module Chapter04.Exercises.Exercise10

let rec prefix elements =
    match elements with
    | ([], []) -> true
    | (x :: xs, y :: ys) ->
        let rest = prefix (xs, ys)
        (x = y) && rest
    | ([], _) -> true
    | (_, _) -> false
