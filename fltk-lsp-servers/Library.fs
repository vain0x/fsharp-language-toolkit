namespace FSharpLanguageToolKit.LspServers

open Utf8Json

module Deserialize =
    let deserialize<'T> (json: string): 'T =
        JsonSerializer.Deserialize<'T>(json, Resolvers.StandardResolver.CamelCase)
