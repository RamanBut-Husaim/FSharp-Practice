module TaggedValues

type Shape = 
    | Circle of float
    | Square of float
    | Triangle of float * float * float

let isShape shape = 
    match shape with
    | Circle r -> r > 0.0
    | Square a -> a > 0.0
    | Triangle(a, b, c) -> a > 0.0 && b > 0.0 && c > 0.0 && a < b + c && b < c + a && c < a + b

let area x = 
    if not (isShape x) then failwith "not a legal shape"
    else 
        match x with
        | Circle r -> System.Math.PI * r * r
        | Square a -> a * a
        | Triangle(a, b, c) -> 
            let s = (a + b + c) / 2.0
            sqrt (s * (s - a) * (s - b) * (s - c))

let a1 = area (Triangle(3.0, 4.0, 5.0))
let a2 = area (Triangle(3.0, 4.0, 7.5))