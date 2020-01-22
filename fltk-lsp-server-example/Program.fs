module FSharpLanguageToolKit.LspServerExamples.Program

open System
open Utf8Json
open FSharpLanguageToolKit.LspTypes
open FSharpLanguageToolKit.LspRequests

module Deserialize =
    type NumberOrStringFormatter() =
        interface IJsonFormatter<NumberOrString> with
            override _.Serialize(writer: byref<JsonWriter>, value: NumberOrString, formatterResolver: IJsonFormatterResolver) =
                match value with
                | NumberOrString.Number value ->
                    formatterResolver.GetFormatter().Serialize(&writer, value, formatterResolver)

                | NumberOrString.String value ->
                    formatterResolver.GetFormatter().Serialize(&writer, value, formatterResolver)

            override _.Deserialize(reader: byref<JsonReader>, formatterResolver: IJsonFormatterResolver) =
                match reader.GetCurrentJsonToken() with
                | JsonToken.Number ->
                    formatterResolver.GetFormatter<float>().Deserialize(&reader, formatterResolver)
                    |> NumberOrString.Number

                | JsonToken.Null
                | JsonToken.String ->
                    formatterResolver.GetFormatter<string>().Deserialize(&reader, formatterResolver)
                    |> NumberOrString.String

                | _ ->
                    // FIXME: error handling
                    failwith "error"

    let resolver =
        let formatters =
            [|
                NumberOrStringFormatter() :> IJsonFormatter
            |]

        let resolvers =
            [|
                Resolvers.StandardResolver.CamelCase
            |]

        Resolvers.DynamicCompositeResolver.Create(formatters, resolvers)

    let deserialize<'T> (json: string): 'T =
        JsonSerializer.Deserialize<'T>(json, resolver)

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
