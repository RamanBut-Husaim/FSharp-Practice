// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Core
    open System

    let goldenRation = (1.0 + Math.Sqrt 5.0) / 2.0

    let getNumberOfElements = 
        printfn "Enter the number of elements"
        let numberOfElements = Console.ReadLine()

        (int numberOfElements)

    let getElements elementNumber =
        printfn "Enter %i real numbers separated by space" elementNumber
        let elementString = Console.ReadLine()

        elementString.Split(' ') |> Array.map(fun n -> float n)

    let displayResult elements =
        printfn "Transformed values: "
        for element in elements do
            printf "%A; " element
        
        0

    [<EntryPoint>]
    let main argv = 
        let numberOfElements = getNumberOfElements
        let elements = getElements numberOfElements

        let result = 
            if numberOfElements = Array.length elements then
                let transformedElements = elements |> Array.map(fun n -> (n, goldenRation * n))
                displayResult transformedElements
            else
                printfn "Incorrect number of elements"
                -1
        
        result // return an integer exit code