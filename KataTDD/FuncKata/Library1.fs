namespace FuncKata
open Xunit

module FuncKata = 
    
    let (|Begin|_|) (p:string) (s:string) =
        if s.StartsWith(p) then
            Some(s)
        else
            None    
             
    let rec getCustomSeparator s separator =
        match s with
          | '\n' :: tail -> getCustomSeparator tail separator
          | head :: tail -> if System.Char.IsDigit(head) 
                                then separator 
                                else getCustomSeparator tail ( Array.concat[ separator; [|head|]])
          | [] -> separator      
         
    let split (s:string) = 
        let listChar =  [for c in s -> c]
        let separator =  getCustomSeparator listChar [|','; '\n'|] 
        Array.toList( s.Split(separator)) 
             |> List.filter (fun x -> x <> "")
      
    let stringToSplit (s:string) =
        match s with
        | Begin "//" s -> s.Substring(2, s.Length - 2)
        | __ -> s
        
    let stringCalculator (s:string) = 
        stringToSplit s
        |> split
        |> List.map System.Int32.Parse
        |> List.sum                
    
    [<Fact>]
    let ``Empty String``() = Assert.True(0 = stringCalculator(""))

    [<Fact>]
    let ``1 String``() = Assert.True(1 = stringCalculator("1"))
    
    [<Fact>]
    let ``2 String``() = Assert.True(2 = stringCalculator("2"))

    [<Fact>]
    let ``1,2 String``() = Assert.True(3 = stringCalculator("1,2"))

    [<Fact>]
    let ``1\n2,3 String``() = Assert.True(6 = stringCalculator("1\n2,3"))

    [<Fact>]
    let ``//;\n1;2 String``() = Assert.True(6 = stringCalculator("//;\n1;2,3"))


