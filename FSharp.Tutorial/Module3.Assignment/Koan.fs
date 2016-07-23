module Koan
    let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9 |]
    let l = arr.Length - 1
    let isEven x = x % 2 = 0

    let out =
        [ for i = 0 to l do
              if (isEven (Array.get arr i)) then 
                yield arr.[i] ]

    let newout = [ 0 ] @ out
