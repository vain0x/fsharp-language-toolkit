namespace rec FSharpLanguageToolKit.LspRequests

open System
open FSharpLanguageToolKit.LspTypes

type JsonRpcVersion = string

type MessageId = NumberOrString

type MessageMethod = string

[<CLIMutable>]
type RequestMessage<'TParams> =
    {
        Jsonrpc: JsonRpcVersion

        Id: MessageId

        Method: MessageMethod

        Params: 'TParams
    }

[<CLIMutable>]
type ResponseMessage<'TResult> =
    {
        Jsonrpc: JsonRpcVersion

        Id: Option<MessageId>

        Method: MessageMethod

        Result: 'TResult

        Error: Option<ResponseError>
    }

[<CLIMutable>]
type ResponseError =
    {
        Code: int

        Message: MessageMethod

        Data: obj
    }

type ErrorCodes private() =
    static member val ParseError = -32700
    static member val InvalidRequest = -32600
    static member val MethodNotFound = -32601
    static member val InvalidParams = -32602
    static member val InternalError = -32603
    static member val ServerErrorStart = -32099
    static member val ServerErrorEnd = -32000
    static member val ServerNotInitialized = -32002
    static member val UnknownErrorCode = -32001

    static member val RequestCancelled = -32800
    static member val ContentModified = -32801

[<CLIMutable>]
type NotificationMessage<'TParams> =
    {
        Jsonrpc: JsonRpcVersion

        Method: MessageMethod

        Params: 'TParams
    }

// FIXME: cancel, progress

[<CLIMutable>]
type InitializeParams =
    {
        ProcessId: Nullable<int64>
    }

[<CLIMutable>]
type InitializeResult =
    {
        A:string
    }

type InitializeRequest =
    RequestMessage<InitializeParams>

type InitializeResponse =
    ResponseMessage<InitializeResult>
