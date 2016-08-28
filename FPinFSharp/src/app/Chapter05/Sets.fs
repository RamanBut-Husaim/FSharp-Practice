module Chapter05.Sets
    let males = Set.ofList ["John"; "Bill"; "Stan"; "Bill"]

    let modifiedMales = Set.add "Corvin" males

    let rec tryFind predicate dataSet =
        if Set.isEmpty dataSet then None
        else
            let minElement = Set.minElement dataSet
            if predicate minElement then Some minElement
            else tryFind predicate (Set.remove minElement dataSet)

    module ``MapColouring`` =
        type Country = string
        type Map = Set<Country * Country>
        type Colour = Set<Country>
        type Colouring = Set<Country>

        let areNeighbours country1 country2 map =
            Set.contains (country1, country2) map || Set.contains (country2, country1) map

        let canBeExtendedBy map colour country =
            Set.forall (fun c -> not (areNeighbours c country map)) colour

        let rec extendColouring map colours country =
            if Set.isEmpty colours
            then Set.singleton (Set.singleton country)
            else
                let colour = Set.minElement colours
                let restColours = Set.remove colour colours
                if canBeExtendedBy map colour country
                then Set.add (Set.add country colour) restColours
                else Set.add colour (extendColouring map restColours country)

        let countries map =
            Set.fold (fun set (country1, country2) -> Set.add country1 (Set.add country2 set)) Set.empty map

        let colourContries map countries = Set.fold (extendColouring map) Set.empty countries

        let colourMap map = colourContries map (countries map)

    module ``ImprovedMapColouring`` =
        type Country = string
        type Map = Set<Country * Country>
        type Colour = Set<Country>
        type Colouring = Colour list

        let areNeighbours country1 country2 map =
            Set.contains (country1, country2) map || Set.contains (country2, country1) map

        let canBeExtendedBy map colour country =
            Set.forall (fun c -> not (areNeighbours c country map)) colour

        let rec extendColouring map colours country =
            match colours with
            | [] -> [Set.singleton country]
            | colour :: colours' ->
                if canBeExtendedBy map colour country
                then (Set.add country colour) :: colours'
                else colour :: (extendColouring map colours' country)

        let countries map =
            Set.fold (fun set (country1, country2) -> Set.add country1 (Set.add country2 set)) Set.empty map

        let colourContries map countries = Set.fold (extendColouring map) [] countries

        let colourMap map = colourContries map (countries map)
