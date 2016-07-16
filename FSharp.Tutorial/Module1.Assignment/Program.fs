// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Main
    open System

    let calculateVolume radius height = Math.PI * Math.Pow(radius, 2.0) * height

    [<EntryPoint>]
    let main argv = 
        Console.WriteLine("Please, enter the radius of the cylinder")
        let radius = Console.ReadLine()
        let radius = float radius

        Console.WriteLine("Please, enter the height of the cylinder")
        let height = Console.ReadLine()
        let height = float height

        let volume = calculateVolume radius height

        Console.WriteLine("The volument is " + (string volume))

        let resultKey = Console.ReadKey()

        0 // return an integer exit code

