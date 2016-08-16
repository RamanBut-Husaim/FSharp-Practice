module Chapter04.Tests.Exercises.Exercise22

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise22

    module ``multiplyByConstant`` =
        [<Fact>]
        let ``multiplyByConstant - when the list is empty - empty list is returned`` () =
            let emptyPolynomial : Polynomial = []
            multiplyByConstant emptyPolynomial 10 |> should equal emptyPolynomial

        [<Fact>]
        let ``multiplyByConstant - when the coefficients are specified - they are increased by multiplier times`` () =
            multiplyByConstant [3; 2; 0; 5] 4 |> should equal [12; 8; 0; 20]

    module ``multiplyByX`` =

        [<Fact>]
        let ``multiplyByX - when the list is empty - zero is added`` () =
            multiplyByX [] |> should equal [0]

        [<Fact>]
        let ``multiplyByX - when the coefficients are specified - zero is added as the first coefficient`` () =
            multiplyByX [3; 12; 2; 3; 5] |> should equal [0; 3; 12; 2; 3; 5]

    module ``addition`` =

        [<Fact>]
        let ``|+| - when polynoms have equal power - they are added correctly`` () =
            [3; 4; 8] |+| [1; 7; 12] |> should equal [4; 11; 20]

        [<Fact>]
        let ``|+| - when the first polynom is higher than the second one - they are added properly`` () =
            [1; 12; 3; 4; 1] |+| [3; 1; 4] |> should equal [4; 13; 7; 4; 1]

        [<Fact>]
        let ``|+| - when the second polynom is higher than the first one - they are added properly`` () =
            [3; 2; 5] |+| [2; 1; 3; 1; 5] |> should equal [5; 3; 8; 1; 5]

    module ``multiplication`` =

        [<Fact>]
        let ``|*| - when the polynomials are of the same power - they are multiplied properly`` () =
            [1; 3; 5] |*| [4; 5; 1] |> should equal [4; 17; 36; 28; 5]
            [2; 4] |*| [5; 8] |> should equal [10; 36; 32]
            [2; 4; 3; 5] |*| [8; 3; 1; 10] |> should equal [16; 38; 38; 73; 58; 35; 50]

        [<Fact>]
        let ``|*| - when the polynomials are of different power - they are mutliplied properly`` () =
            [3; 1] |*| [1; 4; 2] |> should equal [3; 13; 10; 2]
            [4; 2; 3; 5] |*| [1; 3] |> should equal [4; 14; 9; 14; 15]

    module ``toString`` =

        [<Fact>]
        let ``toString - when all coefficients are non-zero - formatted properly`` () =
            toString [3; 4] |> should equal "4x + 3"
            toString [5; 12; 4; 2] |> should equal "2x^3 + 4x^2 + 12x + 5"
            toString [3; 1; 4; 1; 7] |> should equal "7x^4 + x^3 + 4x^2 + x + 3"

        [<Fact>]
        let ``toString - when there are zero coefficients - they are omitted`` () =
            toString [3; 2; 0; 5] |> should equal "5x^3 + 2x + 3"
            toString [1; 0; 0; 2; 8] |> should equal "8x^4 + 2x^3 + 1"
