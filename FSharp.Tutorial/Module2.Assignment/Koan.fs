module Koan
    open System

    let rec operation x = 
        if x = 0 then 1
        else
            operation (x - 1) * x
