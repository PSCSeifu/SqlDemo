namespace SqlDemo

    open System
    open System.Data
    open System.Data.Linq
    open Microsoft.FSharp.Data.TypeProviders
    open Microsoft.FSharp.Linq

    module sqldb = 
        type dbSchema = SqlDataConnection<"Data Source=DEV-SERVER2;User ID=sa;Password=pscpayroll;Initial Catalog=eServices-TEST2;Pooling=False">
        //let db = dbSchema.GetDataContext()
        let db = dbSchema.GetDataContext()

        //Enable the logging of database activity to the console.
        db.DataContext.Log <- System.Console.Out

        let query1 = 
            query {
                for row in db.HelpTopicItem do 
                select row
            }
        query1 |> Seq.iter (fun row -> printfn "%s %s" row.DisplayName row.Body)

