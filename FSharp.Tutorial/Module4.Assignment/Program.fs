// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module Main

open System
open System.IO

type Entry = 
    { X : float
      Y : float
      Speed : float
      ExpectedDistance : float
      Name : string }

[<Literal>]
let gravityConstant = 9.81

let calculateAngle entry = Math.Atan2(entry.Y, entry.X)

let calculateDistance entry = 
    let angle = calculateAngle entry
    (Math.Pow(entry.Speed, 2.0) * Math.Sin(2.0 * angle)) / gravityConstant

let calculateAngleReach entry =
    let arcSinValue = (gravityConstant * entry.ExpectedDistance) / Math.Pow(entry.Speed, 2.0)
    0.5 * Math.Asin(arcSinValue)

let getEntries (filePath : string) = 
    use streamReader = new StreamReader(filePath)
    [ while not streamReader.EndOfStream do
          let rawLine = streamReader.ReadLine()
          let rawValues = rawLine.Split(',')
          yield { X = float rawValues.[0]
                  Y = float rawValues.[1]
                  Speed = float rawValues.[2]
                  ExpectedDistance = float rawValues.[3]
                  Name = rawValues.[4] } ]

let (|Hit|Miss|) entry = 
    match entry with
    | { Entry.ExpectedDistance = expectedDistance } when expectedDistance = (calculateDistance entry) -> Hit
    | _ -> Miss

let extractHitGuns entries = 
    seq { 
        for entry in entries -> 
            match entry with
            | Hit -> Some(entry)
            | Miss -> None
    }

let extractMissGuns entries = 
    seq { 
        for entry in entries -> 
            match entry with
            | Miss -> Some(entry)
            | Hit -> None
    }

let displayHitGuns entries = 
    printfn "Guns that successfully hit the target: "
    for entry in entries do
        match entry with
        | Some value -> printfn "%A" value
        | None -> ()
    0

let displayMissGuns entries = 
    printfn "Guns that miss the target: "
    for entry in entries do
        match entry with
        | Some value -> 
            printfn "%A; Actual distance: %f; Reach angle: %f" value (calculateDistance value) 
                (calculateAngleReach value)
        | None -> ()

    0

let processEntries entries = 
    let hitGuns = extractHitGuns entries
    let missGuns = extractMissGuns entries
    ignore (displayHitGuns hitGuns)
    ignore (displayMissGuns missGuns)

    0

[<EntryPoint>]
let main argv = 
    let entries = getEntries argv.[0]
    ignore (processEntries entries)
    0 // return an integer exit code
