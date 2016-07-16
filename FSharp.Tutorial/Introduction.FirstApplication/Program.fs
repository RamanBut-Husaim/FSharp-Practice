// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Main
    open System

    [<EntryPoint>]
    let main argv = 
        Console.WriteLine("Please enter how far you traveled:")
        let distance = Console.ReadLine()
        let distance = float distance
        Console.Write("Please enter how much fuel you used: ")
        let fuel = Console.ReadLine()
        let fuel = float fuel
        let consumption = distance / fuel
        Console.WriteLine("Your car does a distance of " + (string consumption) + "  per single unit of fuel ")
        let resultKey = Console.ReadKey()
        0 // return an integer exit code