module Exercises.Exercise01

type Period = 
    | AM
    | PM

let timeOfDay01 = (11, 25, AM)
let timeOfDay02 = (1, 3, PM)
let restructureTimeOfDay (hours, minutes, period) = (period, hours, minutes)
let (<.) (x : int * int * Period) (y : int * int * Period) = restructureTimeOfDay x < restructureTimeOfDay y
let (=.) (x : int * int * Period) (y : int * int * Period) = restructureTimeOfDay x = restructureTimeOfDay y
let (>.) (x : int * int * Period) (y : int * int * Period) = restructureTimeOfDay x > restructureTimeOfDay y

type TimeOfDay = 
    { Period : Period
      Hours : int
      Minutes : int }

let timeOfDay03 = 
    { Hours = 11
      Minutes = 25
      Period = AM }

let timeOfDay04 = 
    { Hours = 1
      Minutes = 3
      Period = PM }

let (<..) x y = 
    if x.Period = y.Period then (x.Hours, x.Minutes) < (y.Hours, y.Minutes)
    else x.Period < y.Period
