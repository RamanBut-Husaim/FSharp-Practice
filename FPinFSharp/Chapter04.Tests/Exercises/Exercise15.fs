module Chapter04.Tests.Exercises.Exercise15

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise15

    [<Fact>]
    let ``revrev - when the list is empty - the empty list is returned`` () =
        let expected = [] : int list list
        revrev ([] : int list list) |> should equal expected

    [<Fact>]
    let ``revrev - when the list has elements - it is inverted`` () =
        revrev [[1]; [3]; [5]; [2]] |> should equal [[2]; [5]; [3]; [1]]

    [<Fact>]
    let ``revrev - when the list contains internal list - they are inverted`` () =
        revrev [[4; 2; 3; 5]; [1; 18; 11; 3]] |> should equal [[3; 11; 18; 1]; [5; 3; 2; 4]]
