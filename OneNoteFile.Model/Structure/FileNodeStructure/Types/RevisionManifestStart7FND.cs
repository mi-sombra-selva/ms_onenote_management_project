using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class RevisionManifestStart7FND : IFileNodeBase
    {
        internal RevisionManifestStart6FND Base { get; set; }
        internal ExtendedGUID gctxid { get; set; }
    }
}
