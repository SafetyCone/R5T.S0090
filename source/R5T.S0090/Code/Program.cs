using System;
using System.Threading.Tasks;


namespace R5T.S0090
{
    class Program
    {
        static async Task Main()
        {
            /// Experiments.
            await AssemblyNameExperiments.Instance.GenerateAndCheck_AssemblyNames();

            //PortableExecutableExperiments.Instance.List_Sections();
        }
    }
}