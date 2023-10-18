using System;


namespace R5T.S0090
{
    public class Instances :
        L0055.Instances
    {
        public static L0059.IAssemblyNameOperator AssemblyNameOperator => L0059.AssemblyNameOperator.Instance;
        public static new L0059.IExecutablePathOperator ExecutablePathOperator => L0059.ExecutablePathOperator.Instance;
        public static new L0059.IFileOperator FileOperator => L0059.FileOperator.Instance;
        public static L0059.IFileSystemOperator FileSystemOperator => L0059.FileSystemOperator.Instance;
        public static L0059.IPortableExecutableOperator PortableExecutableOperator => L0059.PortableExecutableOperator.Instance;
    }
}