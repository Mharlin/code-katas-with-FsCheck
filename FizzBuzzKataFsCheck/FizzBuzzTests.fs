module FizzBuzzTests

open FsCheck
open FsCheck.Xunit

[<Property>]
let numberIsReturnedWhenNotDivisableBy3Or5 number = 
    (number % 3 <> 0 && number % 5 <> 0) ==> lazy
    FizzBuzz.run number = number.ToString()
    

[<Property>]
let fizzIsReturnredWhenDivisableBy3() = 
    let numberDivisibleBy3 = 
        Arb.generate<int>
        |> Gen.map ((*) 3) 
        |> Gen.filter (fun n -> n % 5 <> 0) 
        |> Arb.fromGen
    Prop.forAll numberDivisibleBy3 (fun number -> FizzBuzz.run number = "Fizz")

[<Property>]
let buzzIsReturnredWhenDivisableBy5 (PositiveInt number) = 
    let numberDivisibleBy5 = 
        Arb.generate<int> 
        |> Gen.map ((*) 5) 
        |> Gen.filter (fun n -> n % 3 <> 0) 
        |> Arb.fromGen
    Prop.forAll numberDivisibleBy5 (fun number -> FizzBuzz.run number = "Buzz")

[<Property>]
let fizzBuzzIsReturnredWhenDivisableBy3and5 (PositiveInt number) = 
    let numberDivisibleBy3and5 = 
        Arb.generate<int> 
        |> Gen.map ((*) (3 * 5))
        |> Arb.fromGen
    Prop.forAll numberDivisibleBy3and5 (fun number -> FizzBuzz.run number = "FizzBuzz")
