using System;


namespace R5T.S0090
{
    public class FileSystemDemonstrations : IFileSystemDemonstrations
    {
        #region Infrastructure

        public static IFileSystemDemonstrations Instance { get; } = new FileSystemDemonstrations();


        private FileSystemDemonstrations()
        {
        }

        #endregion
    }
}
