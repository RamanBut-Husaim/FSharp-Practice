module Chapter04.Polymorphism

let rec isMember x elements =
    match elements with
    | y :: ys -> x = y || (isMember x ys)
    | [] -> false
