namespace FSharpLanguageToolKit.LspServers

open Utf8Json

module Deserialize =
    let deserialize<'T> (json: string) =
        JsonSerializer.Deserialize<'T>(json)
