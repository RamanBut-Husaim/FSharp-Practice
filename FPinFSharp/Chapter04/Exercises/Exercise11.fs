module Chapter04.Exercises.Exercise11

let rec isWeaklyAscending elements = 
    match elements with
    | [] -> true
    | [ x ] -> true
    | x1 :: x2 :: xs -> 
        let other = isWeaklyAscending xs
        (x1 <= x2) && other

let rec count pair = 
    match pair with
    | ([], x) -> 0
    | (x :: xs, y) when x > y -> 0
    | (x :: xs, y) -> 
        let rest = count (xs, y)
        if (x = y) then (rest + 1)
        else rest

let rec insert elements value = 
    match elements with
    | [] -> [ value ]
    | x :: xs when x <= value -> 
        let rest = insert xs value
        x :: rest
    | x :: xs when x > value -> value :: x :: xs
    | xs -> xs

let rec intersect elements = 
    match elements with
    | ([], []) | ([], _) | (_, []) -> []
    | ([ x ], y :: ys) -> 
        if x <> y then []
        else [ x ]
    | (x :: xs, [ y ]) -> 
        if x <> y then []
        else [ x ]
    | (x1 :: x2 :: xs, y1 :: y2 :: ys) -> 
        if x2 <> y2 then 
            if x1 = x2 then intersect (x2 :: xs, y1 :: y2 :: ys)
            else intersect (x1 :: x2 :: xs, y2 :: ys)
        else 
            let rest = intersect (x2 :: xs, y2 :: ys)
            x1 :: rest

let plus elements = 
    let (firstList, secondList) = elements
    
    let rec plusInternal source result = 
        match source with
        | [] -> result
        | x :: xs -> 
            let insertResult = insert result x
            plusInternal xs insertResult
    plusInternal secondList firstList

let minus elements = 
    let (firstList, secondList) = elements
    
    let remove element listToScan = 
        let rec removeInternal element listToScan removedElements = 
            match listToScan with
            | [] -> removedElements
            | x :: xs when x = element -> xs
            | x :: xs -> removeInternal element xs (removedElements @ [ x ])
        removeInternal element listToScan []
    
    let rec minusInternal original itemsToScan = 
        match original with
        | [] -> []
        | x :: xs -> 
            let clearedItemsToScan = remove x itemsToScan
            let rest = minusInternal xs clearedItemsToScan
            if List.length itemsToScan <> List.length clearedItemsToScan then rest
            else x :: rest
    
    minusInternal firstList secondList