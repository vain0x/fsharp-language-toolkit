namespace FSharpLanguageToolKit.LspRequests

open System

[<CLIMutable>]
type RequestMessage<'TParam> =
    {
        Jsonrpc: string

        // FIXME: Should accommodate strings.
        Id: int64

        Method: string

        /// nullable
        Params: 'TParam
    }

[<CLIMutable>]
type InitializeParams =
    {
        ProcessId: Nullable<int64>
    }

[<CLIMutable>]
type InitializeRequest =
    RequestMessage<InitializeParams>
