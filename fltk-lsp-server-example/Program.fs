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
            "error": {
                "code": 1,
                "data": ["hello", 1]
            }
        }
    """

    let r: InitializeResponse = Deserialize.deserialize json
    printfn "%A" r

    0
