// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module Main

// exercise 2.1
let f n = (n % 2 = 0 || n % 3 = 0) && (n % 5 <> 0)

// exercise 2.2
let rec pow (str : string) n = 
    match n with
    | 0 -> ""
    | t -> str + pow str (n - 1)

// exercise 2.3
let isIthChar (str : string) i ch = 
    match i with
    | t when i < 0 -> false
    | t when i >= (String.length str) -> false
    | t -> str.[t] = ch

// exercise 2.4
let occFromIth (str : string) i ch = 
    match i with
    | t when t < 0 -> 0
    | t when t >= (String.length str) -> 0
    | t -> 
        Seq.skip t str
        |> Seq.filter (fun c -> c = ch)
        |> Seq.length

// exercise 2.5
let occInString (str : string) ch = Seq.filter (fun c -> c = ch) str |> Seq.length
// exercise 2.6
let notDivisible d n = n % d <> 0

// exercise 2.7.1
let rec test a b c = 
    match a with
    | t when a < b -> notDivisible a c && test (a + 1) b c
    | _ -> notDivisible b c

// exercise 2.7.2
let prime (n : uint32) = 
    let upperBound = uint32 (sqrt (float n))
    [| for i = 2u to upperBound do
           yield i |]
    |> Array.exists (fun c -> n % c = 0u)
    |> not

// exercise 2.7.3
let nextPrime (n : uint32) = 
    let upperBound = Microsoft.FSharp.Core.uint32.MaxValue
    seq { 
        for i = (n + 1u) to upperBound do
            yield i
    }
    |> Seq.tryFind (fun c -> prime c)

// exercise 2.8
let rec binomial arg = 
    match arg with
    | (_, 0) -> 1
    | (n, k) when n = k -> 1
    | (n, k) when n > 0 && n > 0 && n > k -> binomial (n - 1, k - 1) + binomial (n - 1, k)
    | _ -> 0

// exercise 2.11
let vat (n : int) x = float n + (float n * x / 100.0)
let unvat (n : int) x = (x - float n) / (float n) * 100.0

// exercise 2.12
let min f =
    let upperBound = Microsoft.FSharp.Core.int.MaxValue
    seq {
        for i = 0 to upperBound do
            yield i
    }
    |> Seq.tryFind (fun c -> (f c) = 0)

// exercise 2.13
let curry f =
    fun x -> 
        fun y ->
            f (x, y)

let uncurry g =
    fun (x, y) ->
        let h = g x
        h y


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code