using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfContextIDsParser
    {
        internal static ObjectSpaceObjectStreamOfContextIDs DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectSpaceObjectStreamOfContextIDs = new ObjectSpaceObjectStreamOfContextIDs();
            var index = startIndex;
            objectSpaceObjectStreamOfContextIDs.Header = ObjectSpaceObjectStreamHeaderParser.DoDeserializeFromByteArray(byteArray, index);
            index += ObjectSpaceObjectStreamHeader.totalSize;

            objectSpaceObjectStreamOfContextIDs.Body = new CompactID[objectSpaceObjectStreamOfContextIDs.Header.Count];
            for (var i = 0; i < objectSpaceObjectStreamOfContextIDs.Header.Count; i++)
            {
                var compactID = CompactIDParser.DoDeserializeFromByteArray(byteArray, startIndex);
                objectSpaceObjectStreamOfContextIDs.Body[i] = compactID;
                index += CompactID.totalSize;
            }

            return objectSpaceObjectStreamOfContextIDs;
        }
    }
}
