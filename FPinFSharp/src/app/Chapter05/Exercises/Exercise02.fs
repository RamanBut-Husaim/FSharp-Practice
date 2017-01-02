module Chapter05.Exercises.Exercise02

let revrev elements =
    let folder entryList state =
        state @ [List.rev entryList]
    List.foldBack folder elements []