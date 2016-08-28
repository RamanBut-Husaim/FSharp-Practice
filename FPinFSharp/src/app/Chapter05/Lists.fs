module Chapter05.Lists

    module ``map function`` =

        let addFsExt = List.map (fun s -> s + ".fs")

        module ``Rational numbers`` =

            // Euclid's algorithm
            let rec gcd args =
                match args with
                | (0, n) -> n
                | (m, n) -> gcd (n % m, m)

            type Qnum = int * int

            let canc (p, q) =
                let sign =
                    if p * q < 0 then -1
                    else 1

                let ap = abs p
                let aq = abs q
                let d = gcd (ap, aq)
                (sign * (ap / d), aq / d)

            let mkQ =
                function
                | (_, 0) -> failwith "Division by zero"
                | pr -> canc pr

            let toString (p : int, q : int) = (string p) + "/" + (string q)

            let intPairToRational = List.map (toString << mkQ)

        module ``area list`` =
            type Shape =
                | Circle of float
                | Square of float
                | Triangle of float * float * float

            let isShape shape =
                match shape with
                | Circle r -> r > 0.0
                | Square a -> a > 0.0
                | Triangle(a, b, c) -> a > 0.0 && b > 0.0 && c > 0.0 && a < b + c && b < c + a && c < a + b

            let area x =
                if not (isShape x) then failwith "not a legal shape"
                else
                    match x with
                    | Circle r -> System.Math.PI * r * r
                    | Square a -> a * a
                    | Triangle(a, b, c) ->
                        let s = (a + b + c) / 2.0
                        sqrt (s * (s - a) * (s - b) * (s - c))

            let areaList = List.map area

    module ``other functions`` =
        let existsResult = List.exists (fun x -> x >= 2) [1; 3; 1; 4]

        let forAllResult = List.forall (fun x -> x >= 2) [1; 3; 1; 4]

        let tryFindResult = List.tryFind (fun x -> x > 3) [1; 5; -2; 8]

        let filterResult = List.filter (fun x -> x > 3) [1; 5; -2; 8]
    module ``fold`` =
        let norm (x1: float, y1: float) = sqrt(x1 * x1 + y1 * y1)
        let vs = [(1.0, 2.0); (2.0, 3.0); (4.0, 5.0)]
        let sumOfNorms vectors = List.fold (fun state (x, y) -> state + norm(x, y)) 0.0 vectors

        let length elements = List.fold (fun e _ -> e + 1) 0 elements

        let reverse elements = List.fold (fun xs x -> x :: xs) [] elements

    module ``fold back`` =
        let append ys zs = List.foldBack (fun x xs -> x :: xs) ys zs

        let unzip elements = List.foldBack (fun (x, y) (xs, ys) -> (x :: xs, y :: ys)) elements ([], [])