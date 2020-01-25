namespace rec FSharpLanguageToolKit.LspTypes

open System
open System.Collections.Generic

[<RequireQualifiedAccess>]
type BooleanOrString =
    | Boolean
        of booleanValue:bool

    | String
        of stringValue:string

[<RequireQualifiedAccess>]
type NumberOrString =
    | Number
        of floatValue:float

    | String
        of stringValue:string

type JsonRpcVersion = string

type MessageId = NumberOrString

type MessageMethod = string

[<CLIMutable>]
type CancelParams =
    {
        id: NumberOrString
    }

type ProgressToken = NumberOrString

[<CLIMutable>]
type ProgressParams<'T> =
    {
        token: ProgressToken
        value: 'T
    }

type DocumentUri = string

[<CLIMutable>]
type Position =
    {
        line: float
        character: float
    }

[<CLIMutable>]
type Range =
    {
        start: Position
        ``end``: Position
    }

[<CLIMutable>]
type Location =
    {
        uri: DocumentUri
        range: Range
    }

[<CLIMutable>]
type LocationLink =
    {
        originSelectionRange: Option<Range>
        targetUri: DocumentUri
        targetRange: Range
        targetSelectionRange: Range
    }

[<CLIMutable>]
type Diagnostic =
    {
        range: Range
        severity: Option<DiagnosticSeverity>
        code: Option<NumberOrString>
        source: Option<string>
        message: string
        tags: Option<DiagnosticTag[]>
        relatedInformation: Option<DiagnosticRelatedInformation[]>
    }

[<RequireQualifiedAccess>]
type DiagnosticSeverity =
    | Error = 1
    | Warning = 2
    | Information = 3
    | Hint = 4

[<RequireQualifiedAccess>]
type DiagnosticTag =
    | Unnecessary = 1
    | Deprecated = 2

[<CLIMutable>]
type DiagnosticRelatedInformation =
    {
        location: Location
        message: string
    }

[<CLIMutable>]
type Command<'TArguments> =
    {
        title: string
        command: string
        arguments: Option<'TArguments>
    }

[<CLIMutable>]
type TextEdit =
    {
        range: Range
        newText: string
    }

[<CLIMutable>]
type TextDocumentEdit =
    {
        textDocument: VersionedTextDocumentIdentifier
        edits: TextEdit[]
    }

[<CLIMutable>]
type CreateFileOptions =
    {
        overwrite: Option<bool>
        ignoreIfExists: Option<bool>
    }

[<CLIMutable>]
type CreateFile =
    {
        kind: string
        uri: DocumentUri
        options: Option<CreateFileOptions>
    }

[<CLIMutable>]
type RenameFileOptions =
    {
        overwrite: Option<bool>
        ignoreIfExists: Option<bool>
    }

[<CLIMutable>]
type RenameFile =
    {
        kind: string
        oldUri: DocumentUri
        newUri: DocumentUri
        options: Option<RenameFileOptions>
    }

[<CLIMutable>]
type DeleteFileOptions =
    {
        recursive: Option<bool>
        ignoreIfNotExists: Option<bool>
    }

[<CLIMutable>]
type DeleteFile =
    {
        kind: string
        uri: DocumentUri
        options: Option<DeleteFileOptions>
    }

[<RequireQualifiedAccess>]
type FileEdit =
    | Text
        of TextDocumentEdit

    | Create
        of CreateFile

    | Rename
        of RenameFile

    | Delete
        of DeleteFile

[<RequireQualifiedAccess>]
type DocumentChange =
    | Documents
        of TextDocumentEdit[]

    | Files
        of FileEdit[]

[<CLIMutable>]
type WorkspaceEdit =
    {
        changes: Option<Dictionary<DocumentUri, TextEdit[]>>
        documentChanges: Option<TextDocumentEdit[]>
    }

[<CLIMutable>]
type WorkspaceEditClientCapabilities =
    {
        documentChanges: Option<bool>
        resourceOperations: Option<ResourceOperationKind[]>
        failureHandling: FailureHandlingKind
    }

// FIXME: string?
[<RequireQualifiedAccess>]
type ResourceOperationKind =
    | Create
    | Rename
    | Delete

// FIXME: string?
[<RequireQualifiedAccess>]
type FailureHandlingKind =
    | Abort
    | Transactional
    | Undo
    | TextOnlyTransaction

[<CLIMutable>]
type TextDocumentIdentifier =
    {
        uri: DocumentUri
    }

[<CLIMutable>]
type TextDocumentItem =
    {
        uri: DocumentUri
        languageId: string
        version: float
        text: string
    }

[<CLIMutable>]
type VersionedTextDocumentIdentifier =
    {
        uri: DocumentUri
        version: Option<int>
    }

[<CLIMutable>]
type TextDocumentPositionParams =
    {
        textDocument: TextDocumentIdentifier
        position: Position
    }

[<CLIMutable>]
type DocumentFilter =
    {
        language: Option<string>
        scheme: Option<string>
        pattern: Option<string>
    }

type DocumentSelector =
    DocumentFilter[]

[<CLIMutable>]
type StaticRegistrationOptions =
    {
        id: Option<string>
    }

[<CLIMutable>]
type TextDocumentRegistrationOptions =
    {
        documentSelector: Option<DocumentSelector>
    }

/// FIXME: string?
type MarkupKind =
    | PlainText
    | Markdown

[<CLIMutable>]
type MarkupContent =
    {
        kind: MarkupKind
        value: string
    }

[<CLIMutable>]
type WorkDoneProgressBegin =
    {
        kind: string
        title: string
        cancellable: Option<bool>
        message: Option<string>
        percentage: Option<float>
    }

[<CLIMutable>]
type WorkDoneProgressReport =
    {
        kind: string
        cancellable: Option<bool>
        message: Option<string>
        percentage: Option<float>
    }

[<CLIMutable>]
type WorkDoneProgressEnd =
    {
        kind: string
        message: Option<string>
    }

[<CLIMutable>]
type WorkDoneProgressParams =
    {
        workDoneToken: Option<ProgressToken>
    }

[<CLIMutable>]
type WorkDoneProgressOptions =
    {
        workDoneProgress: Option<bool>
    }

[<CLIMutable>]
type PartialResultParams =
    {
        partialResultToken: Option<ProgressToken>
    }

[<CLIMutable>]
type RequestMessage<'TParams> =
    {
        jsonrpc: JsonRpcVersion
        id: MessageId
        method: MessageMethod
        ``params``: 'TParams
    }

[<CLIMutable>]
type ResponseMessage<'TResult, 'TErrorData> =
    {
        jsonrpc: JsonRpcVersion
        id: Option<MessageId>
        method: MessageMethod
        result: 'TResult
        error: Option<ResponseError<'TErrorData>>
    }

[<CLIMutable>]
type ResponseError<'TErrorData> =
    {
        code: int
        message: MessageMethod
        data: 'TErrorData
    }

[<AbstractClass>]
[<Sealed>]
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
        jsonrpc: JsonRpcVersion
        method: MessageMethod
        ``params``: 'TParams
    }

[<CLIMutable>]
type ClientInfo =
    {
        name: string
        version: Option<string>
    }

/// FIXME: string?
type Trace =
    | Off
    | Messages
    | Verbose

// type TextDocumentClientCapabilities =
//     {
//         synchronization: Option<TextDocumentSyncClientCapabilities>
//         completion: Option<CompletionClientCapabilities>
//         hover: Option<HoverClientCapabilities>
//         signatureHelp: Option<SignatureHelpClientCapabilities>
//         declaration: Option<DeclarationClientCapabilities>
//         definition: Option<DefinitionClientCapabilities>
//         typeDefinition: Option<TypeDefinitionClientCapabilities>
//         implementation: Option<ImplementationClientCapabilities>
//         references: Option<ReferenceClientCapabilities>
//         documentHighlight: Option<DocumentHighlightClientCapabilities>
//         documentSymbol: Option<DocumentSymbolClientCapabilities>
//         codeAction: Option<CodeActionClientCapabilities>
//         codeLens: Option<CodeLensClientCapabilities>
//         documentLink: Option<DocumentLinkClientCapabilities>
//         colorProvider: Option<DocumentColorClientCapabilities>
//         formatting: Option<DocumentFormattingClientCapabilities>
//         rangeFormatting: Option<DocumentRangeFormattingClientCapabilities>
//         onTypeFormatting: Option<DocumentOnTypeFormattingClientCapabilities>
//         rename: Option<RenameClientCapabilities>
//         publishDiagnostics: Option<PublishDiagnosticsClientCapabilities>
//         foldingRange: Option<FoldingRangeClientCapabilities>
//     }

// type ClientWorkspaceCapabilities =
//     {
//         applyEdit: Option<boolean>
//         workspaceEdit: Option<WorkspaceEditClientCapabilities>
//         didChangeConfiguration: Option<DidChangeConfigurationClientCapabilities>
//         didChangeWatchedFiles: Option<DidChangeWatchedFilesClientCapabilities>
//         symbol: Option<WorkspaceSymbolClientCapabilities>
//         executeCommand: Option<ExecuteCommandClientCapabilities>
//     }

// type ClientCapabilities<'TExperimental> =
//     {
//         workspace: Option<ClientWorkspaceCapabilities>
//         textDocument: Option<TextDocumentClientCapabilities>
//         experimental: 'TExperimental
//     }

[<CLIMutable>]
type ServerInfo =
    {
        name: string
        version: Option<string>
    }

[<CLIMutable>]
type ExecuteCommandOptions =
    {
        commands: string[]
    }

// FIXME: ServerCapabilities

[<CLIMutable>]
type InitializeParams<'TOptions> =
    {
        processId: Option<float>
        clientInfo: Option<ClientInfo>
        rootPath: Option<string>
        rootUri: Option<DocumentUri>
        initializationOptions: 'TOptions
        // capabilities: ClientCapabilities
        trace: Option<Trace>
        // workspaceFolders: Option<WorkspaceFolder[]>
    }

[<CLIMutable>]
type InitializeResult =
    {
        // capabilities: Option<ServerCapabilities>
        serverInfo: Option<ServerInfo>
    }

[<CLIMutable>]
type InitializeError =
    {
        retry: Option<bool>
    }
with
    static member unknownProtocolVersion = 1.0

type InitializeRequest<'TOptions> =
    RequestMessage<InitializeParams<'TOptions>>

type InitializeResponse =
    ResponseMessage<InitializeResult, InitializeError>

type InitializedParams() =
    static member val Default = InitializedParams()

type InitializedNotification =
    NotificationMessage<InitializedParams>

type ShutdownRequest =
    RequestMessage<unit>

type ShutdownResponse =
    ResponseMessage<unit, unit>

type ExitNotification =
    NotificationMessage<unit>

type MessageType =
    | Error = 1
    | Warning = 2
    | Info = 3
    | Log = 4

[<CLIMutable>]
type ShowMessageParams =
    {
        ``type``: float
        message: string
    }

type ShowMessageNotification =
    NotificationMessage<ShowMessageParams>

[<CLIMutable>]
type MessageActionItem =
    {
        title: string
    }

[<CLIMutable>]
type ShowMessageRequestParams =
    {
        ``type``: float
        message: string
        actions: Option<MessageActionItem[]>
    }

type ShowMessageRequest =
    RequestMessage<ShowMessageRequestParams>

[<CLIMutable>]
type LogMessageParams =
    {
        ``type``: float
        message: string
    }

type LogMessageNotification =
    NotificationMessage<LogMessageParams>

[<CLIMutable>]
type WorkDoneProgressCreateParams =
    {
        token: ProgressToken
    }

type WorkDoneProgressCreateRequest =
    RequestMessage<WorkDoneProgressCreateParams>

type WorkDoneProgressCreateResponse =
    ResponseMessage<unit, unit>

type TelemetryNotification<'TParams> =
    NotificationMessage<'TParams>

// FIXME: RegisterCapability
// https://microsoft.github.io/language-server-protocol/specifications/specification-current/#client_registerCapability

// FIXME: WorkspaceFolder request
// https://microsoft.github.io/language-server-protocol/specifications/specification-current/#workspace_workspaceFolders

[<CLIMutable>]
type WorkspaceFoldersServerCapabilities =
    {
        supported: Option<bool>
        changeNotifications: Option<BooleanOrString>
    }

[<CLIMutable>]
type WorkspaceFolder =
    {
        uri: DocumentUri
        name: string
    }

type WorkspaceFoldersRequest =
    RequestMessage<unit>

type WorkspaceFoldersResponse =
    ResponseMessage<Option<WorkspaceFolder[]>, unit>

// https://microsoft.github.io/language-server-protocol/specifications/specification-current/#workspace_didChangeWorkspaceFolders
