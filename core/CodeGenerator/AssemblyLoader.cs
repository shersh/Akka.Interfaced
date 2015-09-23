﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Akka.Interfaced;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGen
{
    static class AssemblyLoader
    {
        private static ResolveEventHandler _lastResolveHandler;

        public static Assembly BuildAndLoad(string[] sourcePaths, string[] referencePaths, string[] defines)
        {
            var assemblyName = Path.GetRandomFileName();
            var syntaxTrees = sourcePaths.Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file))).ToArray();
            var references = referencePaths.Select(file => MetadataReference.CreateFromFile(file)).ToArray();

            // TODO: how to handle defines option?

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: syntaxTrees,
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        Console.Error.WriteLine("{0}: {1} {2}", 
                            diagnostic.Location,
                            diagnostic.Id,
                            diagnostic.GetMessage());
                    }
                    return null;
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);

                    // To load referenced assemblies, set customized resolved during using this assembly.

                    var currentDomain = AppDomain.CurrentDomain;
                    var resolveHandler = new ResolveEventHandler((sender, args) =>
                    {
                        var nameOnly = args.Name.Substring(0, args.Name.IndexOf(","));
                        foreach (var path in referencePaths)
                        {
                            if (path.Contains(nameOnly))
                                return Assembly.LoadFrom(path);
                        }
                        return null;
                    });

                    if (_lastResolveHandler != null)
                        currentDomain.AssemblyResolve -= _lastResolveHandler;
                    currentDomain.AssemblyResolve += resolveHandler;
                    _lastResolveHandler = resolveHandler;

                    var assembly = Assembly.Load(ms.ToArray());
                    return assembly;
                }
            }
        }
    }
}