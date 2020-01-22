namespace rec FSharpLanguageToolKit.LspTypes

open System

type DocumentUri = string

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

        /// nullable
        Code: NumberOrString

        /// nullable
        Source: string

        Message: string

        /// nullable
        Tags: DiagnosticTag[]

        /// nullable
        RelatedInformation: DiagnosticRelatedInformation[]
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

// next: Command
