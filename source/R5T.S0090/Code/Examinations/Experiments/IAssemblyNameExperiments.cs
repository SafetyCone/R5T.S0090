using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0141;
using R5T.T0172;
using R5T.T0213;

namespace R5T.S0090
{
    [ExperimentsMarker]
    public partial interface IAssemblyNameExperiments : IExperimentsMarker
    {
        /// <summary>
        /// For all assemblies in the executable directory,
        /// use portable executable-level code to generate assembly names,
        /// then check assembly names using the .NET platform's assembly name functionality.
        /// </summary>
        public async Task GenerateAndCheck_AssemblyNames()
        {
            /// Inputs.
            var outputFilePath = Instances.FilePaths.OutputTextFilePath;
            var assemblyFilePaths = Instances.ExecutablePathOperator.Get_AssemblyFilePaths();


            /// Run.
            var problems = new Dictionary<IAssemblyFilePath, (IFullAssemblyName Expected, IFullAssemblyName Actual)>();

            foreach (var assemblyFilePath in assemblyFilePaths)
            {
                var expectedFullAssemblyName = Instances.AssemblyNameOperator.Get_FullAssemblyName(
                    assemblyFilePath);

                var actualFullAssemblyName  = await Instances.PortableExecutableOperator.Get_FullAssemblyName(
                    assemblyFilePath);

                var equal = expectedFullAssemblyName.Equals(actualFullAssemblyName);
                if(!equal)
                {
                    problems.Add(assemblyFilePath, (expectedFullAssemblyName, actualFullAssemblyName));
                }
            }

            var lines = problems
                .OrderBy(x => x.Key.Value)
                .Select(x => $"{x.Key}:\n\t{x.Value.Expected}\n\t{x.Value.Actual}")
                .Prepend($"{problems.Count}, problems of {assemblyFilePaths.Length} total\n\tExpected\n\tActual")
                ;

            Instances.FileOperator.Write_Lines_Synchronous(
                outputFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath);
        }
    }
}
