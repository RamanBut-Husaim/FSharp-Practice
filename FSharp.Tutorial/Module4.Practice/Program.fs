// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Main
    open System
    open System.IO

    type Entry = {
        x: int;
        y: int;
        name: string
    }

    let getFileContent (pathToFile: string) = 
        use streamReader = new StreamReader(pathToFile)
        [
            while not streamReader.EndOfStream do
                let rawLine = streamReader.ReadLine()
                let values = rawLine.Split(',')
                yield { x = int values.[0]; y = int values.[1]; name = values.[2] } ]

    let (|Quadrant1|Quadrant2|Quadrant3|Quadrant4|Origin|Undefined|) entry = 
        match entry with
        | { Entry.x = x; Entry.y = y; Entry.name = name } when x > 0 && y > 0 -> Quadrant1
        | { Entry.x = x; Entry.y = y; Entry.name = name } when x < 0 && y > 0 -> Quadrant2
        | { Entry.x = x; Entry.y = y; Entry.name = name } when x < 0 && y < 0 -> Quadrant3
        | { Entry.x = x; Entry.y = y; Entry.name = name } when x > 0 && y < 0 -> Quadrant4
        | { Entry.x = x; Entry.y = y; Entry.name = name } when x = 0 && y = 0 -> Origin
        | _ -> Undefined
    
    let extractUndefinedEntries entries =
        seq {
            for entry in entries ->
                match entry with
                | Undefined -> Some(entry.name)
                | _ -> None
        }

    let extractClassifiedEntries entries =
        seq {
            for entry in entries ->
                match entry with
                | Undefined -> None
                | _ -> Some(entry)
        }

    let displayUndefinedEntries entries =
        printfn "Undefined entries: "
        for entry in entries do
            match entry with
            | Some element -> printfn "%s" element
            | None -> ()
        
        0
    
    let displayClassifiedEntries entries = 
        printfn "Classified entries: "
        for entry in entries do
            match entry with
            | Some Quadrant1 -> printf "%A - Quadrant 1" entry.Value
            | Some Quadrant2 -> printfn "%A - Quadrant 2" entry.Value
            | Some Quadrant3 -> printfn "%A - Quadrant 3" entry.Value
            | Some Quadrant4 -> printfn "%A - Quadrant 4" entry.Value
            | Some Origin    -> printfn "%A - Origin" entry.Value
            | _              -> ()
       
        0

    let displayEntriesInfo entries = 
        let undefinedEntries = extractUndefinedEntries entries
        let classifiedEntries = extractClassifiedEntries entries
        ignore (displayUndefinedEntries undefinedEntries)
        ignore (displayClassifiedEntries classifiedEntries)

        0


    [<EntryPoint>]
    let main argv = 
        let entries = getFileContent argv.[0]
        ignore (displayEntriesInfo entries)
        0 // return an integer exit code

