module Chapter04.ListRecursion

let rec suml elements =
    match elements with
    | [] -> 0
    | x :: xs -> x + suml xs

let rec altsum elements =
    match elements with
    | [] -> 0
    | [ x ] -> x
    | x0 :: x1 :: xs -> x0 - x1 + altsum xs

let rec succPairs elements =
    match elements with
    | x0 :: x1 :: xs -> (x0, x1) :: succPairs (x1 :: xs)
    | _ -> []

let rec succPairs2 elements =
    match elements with
    | x0 :: (x1 :: _ as xs) -> (x0, x1) :: succPairs2 xs
    | _ -> []

let rec sumProd elements =
    match elements with
    | [] -> (0, 1)
    | x :: rest ->
        let (rSum, rProd) = sumProd rest
        (x + rSum, x * rProd)

let rec unzip elements =
    match elements with
    | [] -> ([], [])
    | (x, y) :: rest ->
        let (xs, ys) = unzip rest
        (x :: xs, y :: ys)

let rec mix elements =
    match elements with
    | (x :: xs, y :: ys) -> x :: y :: (mix (xs, ys))
    | ([], []) -> []
    | _ -> failwith "mix: parameter error"

let rec mix2 xlst ylst =
    match (xlst, ylst) with
    | (x :: xs, y :: ys) -> x :: y :: (mix2 xs ys)
    | ([], []) -> []
    | _ -> failwith "mix: parameter error"