module Exercises.Exercise04

// y = ax + b
type StraightLine = 
    { A : float
      B : float }

let getPoint line x = line.A * x + line.B

let mirrorAroundX line = { A = -line.A; B = -line.B }
let mirrorAroundY line = { A = -line.A; B = line.B }

let getStringRepresentation line = "y = " + (string line.A) + "x + " + (string line.B)