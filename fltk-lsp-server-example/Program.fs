module FSharpLanguageToolKit.LspServerExamples.Program

open System
open Utf8Json
open FSharpLanguageToolKit.LspRequests

module Deserialize =
    let deserialize<'T> (json: string): 'T =
        JsonSerializer.Deserialize<'T>(json, Resolvers.StandardResolver.CamelCase)

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

    let r: InitializeRequest = Deserialize.deserialize json
    printfn "%A" r

    0
