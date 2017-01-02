module Chapter05.Exercises.Exercise01

let filter elements fn =
    let folder element state =
        if fn element
            then element :: state
            else state
    List.foldBack folder elements []