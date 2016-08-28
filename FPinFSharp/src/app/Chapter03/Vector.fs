module Vector

let (~-.) (x : float, y : float) = (-x, -y)
let (+.) (x1, y1) (x2, y2) = (x1 + x2, y1 + y2): float * float
let (-.) v1 v2 = v1 +. -.v2
let ( *.) x (x1, y1) = (x * x1, x * y1): float * float
let (&.) (x1, y1) (x2, y2) = x1 * x2 + y1 * y2: float
let norm (x : float, y : float) = sqrt (x * x + y * y)
let a = (1.0, -2.0)
let b = (3.0, 4.0)
let c = 2.0 *. a -. b