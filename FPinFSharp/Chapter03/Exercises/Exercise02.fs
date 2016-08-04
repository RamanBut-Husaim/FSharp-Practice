module Exercises.Exercise02

// tuples
let toPence amount = 
    let (pounds, shillings, pence) = amount
    (pounds * 20 * 12 + shillings * 12 + pence)

let normalizeOldBritishAmount amount = 
    let (pounds, shillings, pence) = amount
    let normalizedPence = pence % 12
    let shillings = shillings + (pence / 12)
    let normalizedShillings = shillings % 20
    let pounds = pounds + (shillings / 20)
    (pounds, normalizedShillings, normalizedPence)

let addOldBritishMoney amount1 amount2 = 
    let totalPence1 = toPence amount1
    let totalPence2 = toPence amount2
    normalizeOldBritishAmount (0, 0, totalPence1 + totalPence2)

let substractOldBritishMoney amount1 amount2 = 
    let totalPence1 = toPence amount1
    let totalPence2 = toPence amount2
    if totalPence1 < totalPence2 then failwith "you ran out of money"
    normalizeOldBritishAmount (0, 0, totalPence1 - totalPence2)

let (.+.) amount1 amount2 = addOldBritishMoney amount1 amount2
let (.-.) amount1 amount2 = substractOldBritishMoney amount1 amount2

// records
type OldMoney = 
    { Pounds : int
      Shillings : int
      Pence : int }

let toPenceRecord amount = (amount.Pounds * 20 * 12 + amount.Shillings * 12 + amount.Pence)

let normalizeOldBritishAmountRecord amount = 
    let normalizedPence = amount.Pence % 12
    let shillings = amount.Shillings + (amount.Pence / 12)
    let normalizedShillings = shillings % 20
    let pounds = amount.Pounds + (shillings / 20)
    { Pounds = pounds; Shillings = normalizedShillings; Pence = normalizedPence }

let addOldBritishMoneyRecord amount1 amount2 = 
    let totalPence1 = toPenceRecord amount1
    let totalPence2 = toPenceRecord amount2
    normalizeOldBritishAmountRecord { Pounds = 0; Shillings = 0; Pence = totalPence1 + totalPence2 }

let substractOldBritishMoneyRecord amount1 amount2 = 
    let totalPence1 = toPenceRecord amount1
    let totalPence2 = toPenceRecord amount2
    if totalPence1 < totalPence2 then failwith "you ran out of money"
    normalizeOldBritishAmountRecord { Pounds = 0; Shillings = 0; Pence = totalPence1 - totalPence2 }

let (|+|) amount1 amount2 = addOldBritishMoneyRecord amount1 amount2
let (|-|) amount1 amount2 = substractOldBritishMoneyRecord amount1 amount2