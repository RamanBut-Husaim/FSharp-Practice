module Chapter04.Tests.Exercises.Exercise14

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise14

    [<Fact>]
    let ``findSmallest - when the list is empty - None is returned`` () =
        findSmallest [] |> should equal None

    [<Fact>]
    let ``findSmallest - when the list contains elements - the smallest is returned`` () =
        findSmallest [-14; 2; 4; 18; -88] |> should equal (Some -88)
