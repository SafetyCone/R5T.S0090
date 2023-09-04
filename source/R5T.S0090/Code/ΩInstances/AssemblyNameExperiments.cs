using System;


namespace R5T.S0090
{
    public class AssemblyNameExperiments : IAssemblyNameExperiments
    {
        #region Infrastructure

        public static IAssemblyNameExperiments Instance { get; } = new AssemblyNameExperiments();


        private AssemblyNameExperiments()
        {
        }

        #endregion
    }
}
