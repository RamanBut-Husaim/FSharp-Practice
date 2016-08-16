module Exercises.Exercise03

let addComplexNumbers first second =
    let (a, b) = first
    let (c, d) = second
    (a + c, b + d) : float * float

let multiplyComplexNumbers first second =
    let (a, b) = first
    let (c, d) = second
    (a * c - b * d, b * c + a * d) : float * float

let negateComplex number =
    let (a, b) = number
    (-a, -b) : float * float

let inverseComplex number =
    match number with
    | (0.0, 0.0) -> failwith "'a' and 'b' could not be equal to 0 at once"
    | (a, b) ->
        let denominator = a * a + b * b
        (a / denominator, -b / denominator)

let (.+.) first second = addComplexNumbers first second
let (.*.) first second = multiplyComplexNumbers first second
let (.-.) first second = first .+. (negateComplex second)
let (./.) first second = first .*. (inverseComplex second)