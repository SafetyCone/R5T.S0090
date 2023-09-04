using System;


namespace R5T.S0090
{
    public class PortableExecutableExperiments : IPortableExecutableExperiments
    {
        #region Infrastructure

        public static IPortableExecutableExperiments Instance { get; } = new PortableExecutableExperiments();


        private PortableExecutableExperiments()
        {
        }

        #endregion
    }
}
