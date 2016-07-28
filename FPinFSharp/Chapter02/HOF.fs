module HigherOrderFunctions

let f = fun y -> y + 3
let g = fun x -> x * x

let h = f << g

let weight ro = fun s -> ro * s ** 3.0

let waterWeight = weight 1000.0

// preferred way of higher order function delcaration
let weightPreferred ro s = ro * s ** 3.0

let someWeight = weightPreferred 3000.0