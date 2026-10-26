using System.Collections.Generic;

namespace Blazonia.ComponentGenerator;

/// <summary>
/// Collects non-fatal notes (skipped members, unusual API shapes) for the end-of-run report.
/// </summary>
internal static class GeneratorLog
{
    public static readonly List<string> Notes = new();

    public static void Note(string message) => Notes.Add(message);
}
