namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class ReadOnlyObjectDeclaration2RefCountFND : IFileNodeBase
    {
        internal ObjectDeclaration2RefCountFND Base { get; set; }
        internal byte[] md5Hash { get; set; }
    }
}
