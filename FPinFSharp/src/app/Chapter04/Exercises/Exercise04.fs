module Chapter04.Exercises.Exercise04

let rec altSumInternal elements signum =
    match elements with
    | [] -> 0
    | x :: xs -> (x * signum) + altSumInternal xs (-signum)

let altsum elements = altSumInternal elements 1
