module Chapter05.Tests.Exercises.Exercise01

    open Xunit
    open FsUnit.Xunit

    open Chapter05.Exercises.Exercise01

    [<Fact>]
    let ``filter - When The List Is Empty - Should Return An Empty Collection`` () =
        filter ([]: int list) (fun x -> true) |> should be Empty

    [<Fact>]
    let ``filter - When The List Is Not Empty - Should Return A Correct Result`` () =
        // arrange
        let elements = [4; 1; 5; 2; 7; 3]
        let filterFunc = fun x -> x % 2 = 0
        let expected = List.filter filterFunc elements

        // act
        let actual = filter elements filterFunc

        // assert
        actual |> should equal expected