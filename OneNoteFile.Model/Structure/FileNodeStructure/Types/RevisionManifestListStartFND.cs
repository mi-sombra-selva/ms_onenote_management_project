using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestListStartFND : IFileNodeBase
    {
        internal ExtendedGUID gosid { get; set; }
        internal byte[] nInstance { get; set; }
    }
}
