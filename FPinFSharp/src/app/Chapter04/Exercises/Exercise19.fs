module Chapter04.Exercises.Exercise19

let rec isMember (x, y) elements =
    match elements with
    | [] -> false
    | z :: zs -> (x, y) = z || (y, x) = z || (isMember (x, y) zs)

// Decides whether two countries are neighbours
let areNb m countries = isMember countries m
