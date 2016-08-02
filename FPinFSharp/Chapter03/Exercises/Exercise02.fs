module Exercises.Exercise02

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