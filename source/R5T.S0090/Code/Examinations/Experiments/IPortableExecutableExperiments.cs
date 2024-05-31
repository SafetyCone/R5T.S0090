using System;
using System.Reflection.Metadata;

using R5T.T0141;


namespace R5T.S0090
{
    [ExperimentsMarker]
    public partial interface IPortableExecutableExperiments : IExperimentsMarker
    {
        public void List_Sections()
        {
            /// Inputs.
            var dllFilePath = Instances.FilePaths.Example_Dll;


            /// Run.
            Instances.PortableExecutableOperator.In_ReaderContext( 
                dllFilePath,
                reader =>
                {
                    var metadataReader = reader.GetMetadataReader();

                    var assemblyDefinition = metadataReader.GetAssemblyDefinition();

                    var name = metadataReader.GetString(assemblyDefinition.Name);
                    var culture = assemblyDefinition.Culture.IsNil
                        ? "neutral"
                        : metadataReader.GetString(assemblyDefinition.Culture)
                        ;
                    var publicKey = assemblyDefinition.PublicKey.IsNil
                        ? "null"
                        : metadataReader.GetBlobReader(assemblyDefinition.PublicKey).ToString()
                        ;

                    Console.WriteLine($"{name} {assemblyDefinition.Version} {culture} {publicKey}");

                    foreach (var sectionHeader in reader.PEHeaders.SectionHeaders)
                    {
                        Console.WriteLine(sectionHeader.Name);
                    }
                });
        }
    }
}
