module Chapter04.Tests.Exercises.Exercise13

    open Xunit
    open FsUnit.Xunit

    open Chapter04.Exercises.Exercise13

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
