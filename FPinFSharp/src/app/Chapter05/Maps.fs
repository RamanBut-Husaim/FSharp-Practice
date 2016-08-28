module Chapter05.Maps
    type ArticleCode = string
    type ArticleName = string
    type NoPieces = int
    type Price = int

    type Register = Map<ArticleCode, ArticleName * Price>
    type Info = NoPieces * ArticleName * Price
    type Infoseq = Info list
    type Bill = Infoseq * Price

    module ``Version1`` =
        type Item = NoPieces * ArticleCode
        type Purchase = Item list

        let rec makeBill1 register = function
            | [] -> ([], 0)
            | (numberOfPieces, articleCode) :: pur ->
                match Map.tryFind articleCode register with
                | Some (aname, aprice) ->
                    let totalPrice = numberOfPieces * aprice
                    let (infos,sumbill) = makeBill1 register pur
                    ((numberOfPieces, aname, totalPrice) :: infos, totalPrice + sumbill)
                | None ->
                    failwith(articleCode + " is an unknown article code")

    module ``Version2`` =
        type Item = NoPieces * ArticleCode
        type Purchase = Item list

        let makeBill reg pur =
            let f (numberOfPieces, articleCode) (infos, billprice) =
                let (aname, aprice) = Map.find articleCode reg
                let tprice = numberOfPieces * aprice
                ((numberOfPieces, aname, tprice) :: infos, tprice + billprice)
            List.foldBack f pur ([], 0)

    module ``Version3`` =
        type Purchase = Map<ArticleCode, NoPieces>

        let makeBill3 reg pur =
            let f ac np (infos,billprice) =
                let (aname, aprice) = Map.find ac reg
                let tprice = np * aprice
                ((np, aname, tprice) :: infos, tprice + billprice)
            Map.foldBack f pur ([],0)