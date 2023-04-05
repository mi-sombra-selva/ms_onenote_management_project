using OneNoteFile.Model.Structure.Other;
using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.FileNodeStructure.Types
{
    internal class ObjectDeclaration2RefCountFND : IFileNodeBase
    {
        internal const int cRefSize = 1;

        internal int Size
        {
            get
            {
                return BlobRef.Size + ObjectDeclaration2Body.totalSize + cRefSize;
            }
        }
        internal FileNodeChunkReference BlobRef { get; set; }
        internal ObjectDeclaration2Body body { get; set; }
        internal byte cRef { get; set; }
        internal ObjectSpaceObjectPropSet PropertySet { get; set; }
    }
}
