using System;
using System.IO;
using System.Reflection;

namespace Fody
{
    /// <summary>
    /// Uses <see cref="Assembly.CodeBase"/> to derive the current directory.
    /// </summary>
    [Obsolete(OnlyForTesting.Message)]
    public static class CodeBaseLocation
    {
        static CodeBaseLocation()
        {
            var assembly = typeof(CodeBaseLocation).Assembly;

            var uri = new UriBuilder(assembly.CodeBase);
            var currentAssemblyPath = Uri.UnescapeDataString(uri.Path);
            var currentDirectory = Path.GetDirectoryName(currentAssemblyPath);
            CurrentDirectory = currentDirectory;
        }

        public static readonly string CurrentDirectory;
    }
}