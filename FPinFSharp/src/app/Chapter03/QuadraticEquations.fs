module QuadraticEquations

type Equation = float * float * float

type Solution = float * float

let solve (a, b, c) =
    let sqrtD =
        let d = b * b - 4.0 * a * c
        if d < 0.0 || a = 0.0
        then failwith "discriminant is negative or a=0.0"
        else sqrt d
    ((-b + sqrtD) / (2.0 * a), (-b - sqrtD) / (2.0 * a))
