module PartialFunctions

let rec optFactorial x =
    match x with
    | 0 -> Some 1
    | n when n > 0 -> Some(n * Option.get (optFactorial (n - 1)))
    | _ -> None