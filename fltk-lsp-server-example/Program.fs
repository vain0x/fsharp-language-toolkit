module FSharpLanguageToolKit.LspServerExamples.Program

open System
open FSharpLanguageToolKit.LspRequests
open FSharpLanguageToolKit.LspServers.Deserialize

[<EntryPoint>]
let main _ =
    let json = """
        {
            "Id": 1,
            "Params": {
                "ProcessId": 1
            }
        }
    """

    let r: InitializeRequest = deserialize json
    printfn "%A" r

    0
