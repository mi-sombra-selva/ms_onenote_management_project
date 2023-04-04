using OneNoteFile.Model.Structure.Other.ObjectInfoDependency;
using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class ObjectInfoDependencyOverridesFND : IFileNodeBase
    {
        internal FileNodeChunkReference Ref { get; set; }
        internal ObjectInfoDependencyOverrideData data { get; set; }
    }
}
