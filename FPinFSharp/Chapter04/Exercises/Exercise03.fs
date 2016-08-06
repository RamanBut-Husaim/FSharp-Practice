module Chapter04.Exercises.Exercise03

let isEven n = n % 2 = 0

let rec evenGenerator number counter = 
    match number with
    | n when counter <= 0 -> []
    | n when isEven n -> 
        let rest = evenGenerator (number + 1) (counter - 1)
        (number :: rest)
    | n -> evenGenerator (number + 1) counter

let evenN n = evenGenerator 0 n
