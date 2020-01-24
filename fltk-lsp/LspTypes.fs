namespace rec FSharpLanguageToolKit.LspTypes

open System
open System.Collections.Generic

// Notes:
// - Records are marked as CLIMutable
//   because of interoperability with C# serializers,
//   e.g. JSON.NET, Utf8Json.
// - Record fields are `camelCase`
//   instead of `PascalCase` (default F# convention)
//   to reduce requirements of serializers.
// - Unions are defined as discriminated unions instead.

type DocumentUri = string

[<RequireQualifiedAccess>]
type NumberOrString =
    | Number
        of floatValue:float

    | String
        of stringValue:string

type ProgressToken = NumberOrString

[<CLIMutable>]
type ProgressParams<'T> =
    {
        token: ProgressToken
        value: 'T
    }

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
        severity: Nullable<DiagnosticSeverity>
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

[<RequireQualifiedAccess>]
type ResourceOperationKind =
    | Create
    | Rename
    | Delete

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
