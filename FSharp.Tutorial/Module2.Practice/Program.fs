// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System

let rec calculateFibonacci (x: int64) = 
    if x = 0L then 0L
    elif x <= 2L then 1L
    else
        calculateFibonacci (x - 1L) + calculateFibonacci (x - 2L)

[<EntryPoint>]
let main argv =
    Console.WriteLine("Please, enter the number to be calculated")
    let value = Console.ReadLine()
    let value = int64 value

    let fibonacci = calculateFibonacci value

    Console.WriteLine("The calculated fibonacci value for " + (string value) + " is " + (string fibonacci))
    let key = Console.ReadKey()
    0 // return an integer exit code

