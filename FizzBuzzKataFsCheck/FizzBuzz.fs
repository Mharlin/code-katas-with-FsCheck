module FizzBuzz
let run (number : int) = 
    match number % 3, number % 5 with
    | 0, 0  -> "FizzBuzz"
    | 0, _  -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> number.ToString()

