module Exercises.Exercise07

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
    match x with
    | _ when not (isShape x) -> None
    | Circle r -> Some(System.Math.PI * r * r)
    | Square a -> Some(a * a)
    | Triangle(a, b, c) -> 
        let s = (a + b + c) / 2.0
        Some(sqrt (s * (s - a) * (s - b) * (s - c)))
