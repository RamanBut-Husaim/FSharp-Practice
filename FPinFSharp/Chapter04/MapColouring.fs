module Chapter04.MapColouring

type Country = string

type Map = (Country * Country) list

type Colour = Country list

type Colouring = Colour list

let rec isMember x elements = 
    match elements with
    | y :: ys -> x = y || (isMember x ys)
    | [] -> false

// Decides whether two countries are neighbours
let areNb m c1 c2 = isMember (c1, c2) m || isMember (c2, c1) m

// Decides whether a colour can be extended by a country
let rec canBeExtBy m col c = 
    match col with
    | [] -> true
    | c' :: col' -> not (areNb m c' c) && canBeExtBy m col' c

// Extends a colouring by an extra country
let rec extColouring m cols c = 
    match cols with
    | [] -> [ [ c ] ]
    | col :: cols' -> 
        if canBeExtBy m col c then (c :: col) :: cols'
        else col :: extColouring m cols' c

let addElem x ys = 
    if isMember x ys then ys
    else x :: ys

// Computes a list of countries in a map
let rec countries = 
    function 
    | [] -> []
    | (c1, c2) :: m -> addElem c1 (addElem c2 (countries m))

// Builds a colouring for a list of countries
let rec colCntrs m = 
    function 
    | [] -> []
    | c :: cs -> extColouring m (colCntrs m cs) c

let colMap m = colCntrs m (countries m)

let exMap = [("a","b"); ("c","d"); ("d","a")]