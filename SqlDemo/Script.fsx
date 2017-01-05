#r "System.data.dll"
#r "FSharp.data.TypeProviders.dll" 
#r "System.Data.Linq.dll"

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

type dbSchema = SqlDataConnection<"Data Source=DEV-SERVER2;User ID=sa;Password=pscpayroll;Initial Catalog=eServices-TEST2;Pooling=False">
let db = dbSchema.GetDataContext()

///Enable the logging of database activity to the console.
//db.DataContext.Log <- System.Console.Out 

//------------------------------------------------------------------------------  
//let query1 = 
//    query {
//        for row in db.HelpTopicItem do 
//        where (row.Id < 12)
//        select row
//    }
//query1 |> Seq.iter (fun row -> printfn "%s %s" row.DisplayName row.Body)

//------------------------------------------------------------------------------
///Second query without the query variable and using the pipeline operator.

//query {
//    for row in dbSchema.GetDataContext().BankHoliday do 
//    where (row.Id > 1)
//    select row
//} |> Seq.iter(fun row -> printfn "%s %s" (row.HolidayDate.ToString()) row.Description)

//------------------------------------------------------------------------------
////Third query - join two tables

//query {
//    for ht in db.HelpTopic do
//    join hti in db.HelpTopicItem on (ht.Id = (int) hti.HelpTopicId)
//    where (ht.Heading = "New Starters")
//    select(ht, hti)
//} |> Seq.iteri ( fun index (ht, hti) ->
//                 if (index =0) then printfn "Heading | LinkedTo | Body"
//                 printfn "%s | %s | %s" ht.Heading hti.LinkedTo hti.Body)


//------------------------------------------------------------------------------
////Fourth Query - Parameterised query
//let findContact param = 
//   query {
//    for row in db.Contact do 
//    where (row.Surname = param)
//    select row
//   }
//findContact "Warwick"  |> Seq.iter (fun row -> printfn "Contact is: %s %s with email [ %s ]"  row.Forename1 row.Surname row.Email)

//------------------------------------------------------------------------------
//// 5 - using nullable fields
query {
    for c in db.Contact do
    where ( c.Email.Contains("cam.ac.uk") )
    select c
 } |> Seq.iter ( fun c -> printfn "%b | %s | %s"  (c.IsActioned.GetValueOrDefault()) c.Email c.PhoneNo) 

//------------------------------------------------------------------------------


//------------------------------------------------------------------------------
