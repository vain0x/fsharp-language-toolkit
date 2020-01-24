# F# Language Toolkit

**Development status: under construction.**

PRs are welcome.

- [ ] JSON RPC
- [ ] Language server protocol (LSP) type definitions for serialize/deserialize
    - Working in in fltk-lsp/LspTypes.fs
- [ ] LSP server core implementations
- [ ] LSP server implementation example
- [ ] Debug adapter protocol (DAP) type definitions for serialize/deserialize
- [ ] DAP server implementation example

## Types for (De)Serialization

- Records are marked as CLIMutable
    because of good interoperability with C# serializers,
    e.g. Utf8Json.
- Record fields are `camelCase`
    instead of `PascalCase` (the conventional choice in the F# community)
    to reduce requirements of serializers.
- Unions are defined as discriminated unions instead.
- TBD:
    - array vs. list
    - Map vs. Dictionary
    - string + const vs. discriminated unions

## Links

- [JSON RPC specification](https://www.jsonrpc.org/specification)
- [Language server protocol (LSP) specification](https://microsoft.github.io/language-server-protocol/specifications/specification-current/)
- [Debug adapter protocol (DAP) specification](https://microsoft.github.io/debug-adapter-protocol/specification)
