module HigherOrderFunctions

let f = fun y -> y + 3
let g = fun x -> x * x

let h = f << g

let weight ro = fun s -> ro * s ** 3.0