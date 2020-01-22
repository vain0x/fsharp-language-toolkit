namespace FSharpLanguageToolKit.LspRequests

open System

[<CLIMutable>]
type InitializeParams =
    {
        ProcessId: Nullable<int64>
    }

[<CLIMutable>]
type InitializeRequest =
    {
        Id: int64
        Params: InitializeParams
    }
