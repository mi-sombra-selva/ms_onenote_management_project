using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class ObjectSpaceManifestListReferenceFND : IFileNodeBase
    {
        internal FileNodeChunkReference refField { get; set; }
        internal ExtendedGUID gosid { get; set; }
    }
}
