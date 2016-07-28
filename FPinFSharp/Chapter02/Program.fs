// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Main

// exercise 2.1
let f n = (n % 2 = 0 || n % 3 = 0 ) && (n % 5 <> 0)

// exercise 2.2
let rec pow (str: string) n =
    match n with
    | 0 -> ""
    | t -> str + pow str (n - 1)

// exercise 2.3
let isIthChar (str: string) i ch =
    match i with
    | t when i < 0 -> false
    | t when i >= (String.length str) -> false
    | t -> str.[t] = ch

// exercise 2.4
let occFromIth (str: string) i ch =
    match i with
    | t when t < 0 -> 0
    | t when t >= (String.length str) -> 0
    | t -> Seq.skip t str |> Seq.filter (fun c -> c = ch) |> Seq.length

// exercise 2.5
let occInString (str: string) ch =
    Seq.filter (fun c -> c = ch) str |> Seq.length

// exercise 2.6
let notDivisible d n = n % d <> 0

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code