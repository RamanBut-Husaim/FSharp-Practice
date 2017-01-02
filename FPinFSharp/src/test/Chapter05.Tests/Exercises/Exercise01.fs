module Chapter05.Tests.Exercises.Exercise01

    open Xunit
    open FsUnit.Xunit

    open Chapter05.Exercises.Exercise01

    [<Fact>]
    let ``filter - When The List Is Empty - Should Return An Empty Collection`` () =
        filter []: int list (fn x -> true) |> should be empty