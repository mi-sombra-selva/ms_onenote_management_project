using OneNoteFile.Model.Types;

namespace OneNoteFile.Model.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfContextIDs
    {
        internal int Size
        {
            get
            {
                return ObjectSpaceObjectStreamHeader.totalSize + CompactID.totalSize * Body.Length;
            }
        }

        internal ObjectSpaceObjectStreamHeader Header { get; set; }
        internal CompactID[] Body { get; set; }
    }
}
