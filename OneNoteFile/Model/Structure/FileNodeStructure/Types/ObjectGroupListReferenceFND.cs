using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class ObjectGroupListReferenceFND : IFileNodeBase
    {
        internal FileNodeChunkReference Ref { get; set; }
        internal ExtendedGUID ObjectGroupID { get; set; }
    }
}
