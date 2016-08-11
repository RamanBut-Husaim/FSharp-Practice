module Chapter04.Tests.Exercises.Exercise13

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise13

    module ``findSmallest`` =
        [<Fact>]
        let ``findSmallest - when the list is empty - int.MaxValue is returned`` () =
            findSmallest [] |> should equal System.Int32.MaxValue
        
        [<Fact>]
        let ``findSmallest - when the list contains positive values - the smallest value is returned`` () =
            findSmallest [1; 3; 4; 1; 3; 5; 13; 22] |> should equal 1
        
        [<Fact>]
        let ``findSmallest - when the list contains negative values - the smallest value is returned`` () =
            findSmallest [-1; -4; -122; -57; -91; -281] |> should equal -281

        [<Fact>]
        let ``findSmallest - when the list contains positive and negative values - the smallest value is returned`` () =
            findSmallest [-34; 11; 34; 182; -918; 741; 334; 123] |> should equal -918

    module ``delete`` =
        [<Fact>]
        let ``delete - when the list contains the value - it is removed`` () =
            delete (13, [1; 14; 13; 15; 22]) |> should equal [1; 14; 15; 22]
        
        [<Fact>]
        let ``delete - when the list contains several occurances - the first one is deleted`` () =
            delete (13, [3; 12; 55; 12; 13; 55; 13; 71; 99]) |> should equal [3; 12; 55; 12; 55; 13; 71; 99]
        
        [<Fact>]
        let ``delete - when the value does not exist in the list - the list is unchanged`` () =
            delete (31, [1; 2; 3; 4; 5]) |> should equal [1; 2; 3; 4; 5]
    
    module ``bruteSort`` =
        [<Fact>]
        let ``bruteSort - when the list is specified - it is sorted`` () =
            bruteSort [5; 1; 2; 18; 31; 21; 7] |> should equal [1; 2; 5; 7; 18; 21; 31]
        
        [<Fact>]
        let ``bruteSort - when the list contains repeated values - it is sorted`` () =
            bruteSort [-1; 13; -22; 17; 4; 1; 4] |> should equal [-22; -1; 1; 4; 4; 13; 17]
