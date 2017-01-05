//#r "System.data.dll"
//#r "FSharp.data.TypeProviders.dll" 
//#r "System.Data.Linq.dll"

#r "System.dll"


open System
open System.Net
open System.Data
open Microsoft.FSharp.Linq 

// Arrays - Option data type 
//module FunctionalDataStructuresDemo

let GetRequests() = 
    let requests = [|
                        "http://www.rt.com"
                        "http://zerohedge.com"
                        "http://99.99.99.99/doesntexist"
                    |]

    use wc = new WebClient()

//    requests
//    |> Array.map ( fun url ->
//        try
//            wc.DownloadString(url) |> Some
//        with  
//        | _ -> None )
//    |> Array.filter (fun s -> s.IsSome)
//    |> Array.map (fun s -> s.Value)
//    |> Array.iter (fun s-> printfn "Content: %s" (s.Trim().Substring(1000,2000)) )

//    requests
//    |> Array.choose ( fun url ->
//        try
//            wc.DownloadString(url) |> Some
//        with  
//        | _ -> None )
//    |> Array.iter (fun s-> printfn "Content: %s" (s.Trim().Substring(1000,2000)) )

    requests
    |> Array.choose ( fun url ->
        try
            wc.DownloadString(url) |> Some
        with  
        | _ -> None )
    |> Array.sumBy ( fun s ->s.Length)
    //|> Array.sum



