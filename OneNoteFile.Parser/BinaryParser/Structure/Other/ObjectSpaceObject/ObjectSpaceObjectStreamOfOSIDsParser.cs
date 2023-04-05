using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfOSIDsParser
    {
        internal static ObjectSpaceObjectStreamOfOSIDs DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectSpaceObjectStreamOfOSIDs = new ObjectSpaceObjectStreamOfOSIDs();
            var index = startIndex;
            objectSpaceObjectStreamOfOSIDs.Header = ObjectSpaceObjectStreamHeaderParser.DoDeserializeFromByteArray(byteArray, index);
            index += ObjectSpaceObjectStreamHeader.totalSize;

            objectSpaceObjectStreamOfOSIDs.Body = new CompactID[objectSpaceObjectStreamOfOSIDs.Header.Count];
            for (var i = 0; i < objectSpaceObjectStreamOfOSIDs.Header.Count; i++)
            {
                var compactID = CompactIDParser.DoDeserializeFromByteArray(byteArray, index);
                objectSpaceObjectStreamOfOSIDs.Body[i] = compactID;
                index += CompactID.totalSize;
            }

            return objectSpaceObjectStreamOfOSIDs;
        }
    }
}
