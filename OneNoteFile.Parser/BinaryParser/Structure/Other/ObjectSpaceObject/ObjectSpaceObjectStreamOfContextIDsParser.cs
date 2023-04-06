using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfContextIDsParser
    {
        internal static ObjectSpaceObjectStreamOfContextIDs DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectSpaceObjectStreamOfContextIDs = new ObjectSpaceObjectStreamOfContextIDs();
            var index = startIndex;
            objectSpaceObjectStreamOfContextIDs.Header = ObjectSpaceObjectStreamHeaderParser.DoDeserializeFromByteArray(reader, index);
            index += ObjectSpaceObjectStreamHeader.totalSize;

            objectSpaceObjectStreamOfContextIDs.Body = new CompactID[objectSpaceObjectStreamOfContextIDs.Header.Count];
            for (var i = 0; i < objectSpaceObjectStreamOfContextIDs.Header.Count; i++)
            {
                var compactID = CompactIDParser.DoDeserializeFromByteArray(reader, startIndex);
                objectSpaceObjectStreamOfContextIDs.Body[i] = compactID;
                index += CompactID.totalSize;
            }

            return objectSpaceObjectStreamOfContextIDs;
        }
    }
}
