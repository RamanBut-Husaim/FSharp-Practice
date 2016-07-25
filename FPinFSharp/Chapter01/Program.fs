// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module Core

open System

// Euclid's algorithm
let rec gcd args = 
    match args with
    | (0, n) -> n
    | (m, n) -> gcd (n % m, m)

// exercise 1.1
let g n = n + 4
// exercise 1.2
let h (x, y) = Math.Sqrt(x ** 2.0 + y ** 2.0)

// exercise 1.4
let rec f n = 
    match n with
    | 0 -> 0
    | n -> n + f (n - 1)

// exercise 1.5
let rec fib n = 
    match n with
    | 0 -> 0
    | 1 -> 1
    | n -> fib (n - 1) + fib (n - 2)

// exercise 1.6
let rec sum tup = 
    match tup with
    | (m, 0) -> m
    | (m, n) -> (m + n) + sum (m, n - 1)

// exercise 1.8
let a = 5
let f a = a + 1
let g b = (f b) + a

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
