module Chapter04.Exercises.Exercise22

type Polynomial = int list

let rec multiplyByConstant polynomial multiplier = 
    match polynomial with
    | [] -> []
    | coefficient :: otherCoefficients -> 
        let rest = multiplyByConstant otherCoefficients multiplier
        (coefficient * multiplier) :: rest

let multiplyByX polynomial = 0 :: polynomial

let (|+|) polynomial1 polynomial2 = 
    let polynomials = 
        if List.length polynomial1 > List.length polynomial2 then (polynomial1, polynomial2)
        else (polynomial2, polynomial1)
    
    let rec addition polynomials = 
        match polynomials with
        | (higher, []) -> higher
        | (hCoefficient :: hOthers, lCoefficient :: lOthers) -> 
            let rest = addition (hOthers, lOthers)
            (hCoefficient + lCoefficient) :: rest
        | (_, _) -> []
    
    addition polynomials

let (|*|) polynomial1 polynomial2 = 
    let rec multiplication polynomial1 polynomial2 = 
        match polynomial1 with
        | [] -> []
        | coefficient :: others -> 
            let multipliedByCoefficient = multiplyByConstant polynomial2 coefficient
            let rest = multiplication others polynomial2
            let multipliedByX = multiplyByX rest
            multipliedByCoefficient |+| multipliedByX
    multiplication polynomial1 polynomial2

let toString polynomial = 
    let emptyString = System.String.Empty
    
    let rec toString power polynomial = 
        let getSignString coefficient elements = 
            if elements = List.empty then emptyString
            else if coefficient < 0 then " - "
            else " + "
        
        let getCoefficientString power coefficient = 
            let coefficientString = string (abs coefficient)
            if power = 0 || coefficient <> 1 then coefficientString
            else emptyString
        
        let getPowerString power = 
            if power = 1 then emptyString
            else "^" + string power
        
        match polynomial with
        | [] -> emptyString
        | coefficient :: other -> 
            let rest = toString (power + 1) other
            
            let segment = 
                if coefficient = 0 then emptyString
                else 
                    let signString = getSignString coefficient other
                    let coefficientString = getCoefficientString power coefficient
                    if power = 0 then signString + coefficientString
                    else signString + coefficientString + "x" + getPowerString power
            rest + segment
    toString 0 polynomial
