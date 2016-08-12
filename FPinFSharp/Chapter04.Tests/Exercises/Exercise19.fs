module Chapter04.Tests.Exercises.Exercise19

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise19

    [<Fact>]
    let ``areNb - when the country pair strictly presents in the list - true is returned`` () =
        areNb [(1, 3); (1, 4); (2, 8); (6, 1)] (2, 8) |> should equal true
    
    [<Fact>]
    let ``areNb - when the country pair presents in the list in the inverted form - true is returned`` () =
        areNb [(3, 1); (8, 2); (16, 1); (11, 4)] (1, 16) |> should equal true

    [<Fact>]
    let ``areNb - when there is not country pair in the list - false is returned`` () =
        areNb [(1, 12); (8, 5); (11, 71)] (3, 18) |> should equal false