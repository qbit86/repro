# Cleanup emits redundant newline when the namespace declaration is file-scoped

## Steps to reproduce

Declare two C# classes, one inside block-scoped namespace declaration, the other inside file-scoped.

```cs
namespace Repro
{
    public static class BlockScoped { }
}

```

```cs
namespace Repro;

public static class FileScoped { }

```

Set this style in EditorConfig to make the cleanup respect these intentions.

```ini
[*]
insert_final_newline = true

[BlockScoped.cs]
csharp_style_namespace_declarations = block_scoped:warning

[FileScoped.cs]
csharp_style_namespace_declarations = file_scoped:warning
```

Run _Reformat and Cleanup Code_, Scope: _Whole Solution_, Profile: _Build-in: Full Cleanup_.

You can see the minimal repro and download the project here:
- https://github.com/qbit86/repro-repo/tree/feature/2022/cleanup-file-scoped-namespace
- https://github.com/qbit86/repro-repo/archive/refs/heads/feature/2022/cleanup-file-scoped-namespace.zip

## Expected behavior

Cleanup won't add any newlines.

## Observed behavior

Cleanup adds a newline to the end of the file with a file-scoped namespace on every run.
The layout of the block-scoped namespace remains intact.

This issue is a regression: it doesn't reproduce in Rider 2022.2.4, but affects Rider 2022.3.EAP8.

---

Version: 2022.3 EAP 8  
Build: 223.7571.24  
.NET 7.0.0 (Server GC)
