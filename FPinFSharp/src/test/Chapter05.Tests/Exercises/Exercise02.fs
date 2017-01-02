module Chapter05.Tests.Exercises.Exercise02

    open Xunit
    open FsUnit.Xunit

    open Chapter05.Exercises.Exercise02

    [<Fact>]
    let ``revrev - When The List Is Empty - Should Return Emtpy List`` () =
        // arrange
        let elements = [] : int list list

        // act assert
        revrev elements |> should be Empty

    [<Fact>]
    let ``revrev - When The List Contains Elements - Should Return Correct Result`` () =
        // arrange
        let elements = [[3; 1; 5]; [8; 1; 12]]
        let expected = [[12; 1; 8]; [5; 1; 3]]

        // act
        let actual = revrev elements

        // assert
        actual |> should equal expected