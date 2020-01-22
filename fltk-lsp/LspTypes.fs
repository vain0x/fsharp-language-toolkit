namespace rec FSharpLanguageToolKit.LspTypes

open System

// FIXME: JsonValue?
type Any = obj

type DocumentUri = string

// NOTE: Not marked as struct because struct unions can't be deserialized
//       with Utf8Json (as far as I know).
[<RequireQualifiedAccess>]
type NumberOrString =
    | Number
        of floatValue:float

    | String
        of stringValue:string

[<CLIMutable>]
[<Struct>]
type Position =
    {
        Line: int
        Character: int
    }

[<CLIMutable>]
[<Struct>]
type Range =
    {
        Start: Position
        End: Position
    }

[<CLIMutable>]
type Location =
    {
        Uri: DocumentUri
        Range: Range
    }

[<CLIMutable>]
type LocationLink =
    {
        OriginSelectionRange: Nullable<Range>
        TargetUri: DocumentUri
        TargetRange: Range
        TargetSelectionRange: Range
    }

[<CLIMutable>]
type Diagnostic =
    {
        Range: Range
        Severity: Nullable<DiagnosticSeverity>
        Code: Option<NumberOrString>
        Source: Option<string>
        Message: string
        Tags: Option<DiagnosticTag[]>
        RelatedInformation: Option<DiagnosticRelatedInformation[]>
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
        Location: Location
        Message: string
    }

[<CLIMutable>]
type Command<'TArguments> =
    {
        Title: string
        Command: string
        Arguments: Option<'TArguments>
    }

[<CLIMutable>]
type TextEdit =
    {
        Range: Range
        NewText: string
    }

[<CLIMutable>]
type TextDocumentEdit =
    {
        TextDocument: VersionedTextDocumentIdentifier
        Edits: TextEdit[]
    }

[<CLIMutable>]
type CreateFileOptions =
    {
        Overwrite: Option<bool>
        IgnoreIfExists: Option<bool>
    }

[<CLIMutable>]
type CreateFile =
    {
        Kind: string
        Uri: DocumentUri
        Options: Option<CreateFileOptions>
    }

[<CLIMutable>]
type RenameFileOptions =
    {
        Kind: string
        OldUri: DocumentUri
        NewUri: DocumentUri
        Options: Option<RenameFileOptions>
    }

[<CLIMutable>]
type DeleteFileOptions =
    {
        Recursive: Option<bool>
        IgnoreIfNotExists: Option<bool>
    }

[<CLIMutable>]
type DeleteFile =
    {
        Kind: string
        Uri: DocumentUri
        Options: Option<DeleteFileOptions>
    }

// next: WorkspaceEdit







[<CLIMutable>]
[<Struct>]
type TextDocumentIdentifier =
    {
        Uri: DocumentUri
    }

[<Struct>]
type VersionedTextDocumentIdentifier =
    {
        Uri: DocumentUri
        Version: Option<int>
    }
