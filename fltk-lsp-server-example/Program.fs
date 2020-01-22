module FSharpLanguageToolKit.LspServerExamples.Program

open System
open FSharpLanguageToolKit.LspRequests
open FSharpLanguageToolKit.LspServers.Deserialize

[<EntryPoint>]
let main _ =
    let json = """
        {
            "jsonrpc": "2.0",
            "id": 1,
            "params": {
                "processId": 1
            }
        }
    """

    let r: InitializeRequest = deserialize json
    printfn "%A" r

    0
