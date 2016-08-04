module Exercises.Exercise05

type Solution = 
    | TwoRootes of float * float
    | OneRoot of float
    | NoRoot

let solve (a, b, c) = 
    let d = b * b - 4.0 * a * c
    match d with
    | t when d < 0.0 || a = 0.0 -> NoRoot
    | 0.0 -> OneRoot((-b + (sqrt d)) / (2.0 * a))
    | t -> 
        let sqrtD = sqrt d
        TwoRootes((-b + sqrtD) / (2.0 * a), (-b - sqrtD) / (2.0 * a))