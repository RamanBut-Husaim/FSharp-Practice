module Chapter04.Tests.Exercises.Exercise12

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise12

    [<Fact>]
    let ``Sum - When the empty list is specified - Zero is returned`` () =
        sum ((fun s -> s % 2 = 0), []) |> should equal 0

    [<Fact>]
    let ``Sum - When the function extracts odd numbers - the result is their sum `` () =
        sum ((fun s -> s % 2 <> 0), [1; 2; 3; 4; 5; 6; 7; 8; 9]) |> should equal 25

    [<Fact>]
    let ``Sum - When the function extracts even numbers - the result is their sum`` () =
        sum ((fun s -> s % 2 = 0), [2; 4; 5; 6]) |> should equal 12
