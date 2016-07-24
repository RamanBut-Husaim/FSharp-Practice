module Koan

type MyRecord = 
    { IP : string
      MAC : string
      FriendlyName : string
      ID : int }

let IsMatchByName record1 name = 
    match record1 with
    | { MyRecord.FriendlyName = nameFound; MyRecord.ID = _; MyRecord.IP = _ } when nameFound = name -> 
        Some((record1.ID, record1.IP))
    | _ -> None

let checkmatch input = 
    match input with
    | Some x -> printfn "%A" x
    | None -> printfn "%A" "Sorry no match"

let value = 
    { IP = "10.1.1.1"
      MAC = "FF:FF:FF:FF:FF:FF"
      FriendlyName = "ServerFailure"
      ID = 0 }

checkmatch (IsMatchByName value "ServerFailure")