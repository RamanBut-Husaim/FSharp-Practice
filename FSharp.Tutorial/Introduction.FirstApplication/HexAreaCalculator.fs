module HexAreaCalculator
    open System

    let hexArea (t: float) = ((3.0 * Math.Sqrt(3.0)) / 2.0) * Math.Pow(t, 2.0)

    let testHexArea = hexArea 3.0
