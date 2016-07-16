module DegreeRadianConverter

    open System

    let degreeToRadian (degree: float) = degree * Math.PI / 180.0
    let radianToDegree (radian: float) = radian * 180.0 / Math.PI


    let testDegreeToRadian = degreeToRadian 180.0
    let testRadianToDegree = radianToDegree testDegreeToRadian