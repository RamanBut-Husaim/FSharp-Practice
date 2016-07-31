module RationalNumbers

// Euclid's algorithm
let rec gcd args = 
    match args with
    | (0, n) -> n
    | (m, n) -> gcd (n % m, m)

type Qnum = int * int

let canc (p, q) = 
    let sign = 
        if p * q < 0 then -1
        else 1
    
    let ap = abs p
    let aq = abs q
    let d = gcd (ap, aq)
    (sign * (ap / d), aq / d)

let mkQ = 
    function 
    | (_, 0) -> failwith "Division by zero"
    | pr -> canc pr

let (.+.) (a, b) (c, d) = canc (a * d + b * c, b * d) // Addition
let (.-.) (a, b) (c, d) = canc (a * d - b * c, b * d) // Substraction
let (.*.) (a, b) (c, d) = canc (a * c, b * d) // Multiplication
let (./.) (a, b) (c, d) = (a, b) .*. mkQ (d, c) // Division
let (.=.) (a, b) (c, d) = (a, b) = (c, d) // Equality
let toString (p : int, q : int) = (string p) + "/" + (string q)
let q1 = mkQ (2, -3)
let q2 = mkQ (5, 10)
let q3 = q1 .+. q2
let s = toString (q1 .-. q3 ./. q2)