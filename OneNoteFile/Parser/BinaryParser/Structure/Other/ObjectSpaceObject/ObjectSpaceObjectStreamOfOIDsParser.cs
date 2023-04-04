using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;
using OneNoteFile.Model.Types;
using OneNoteFile.Parser.BinaryParser.Types;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamOfOIDsParser
    {
        public static ObjectSpaceObjectStreamOfOIDs DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var objectSpaceObjectStreamOfOIDs = new ObjectSpaceObjectStreamOfOIDs();
            var index = startIndex;
            objectSpaceObjectStreamOfOIDs.Header = ObjectSpaceObjectStreamHeaderParser.DoDeserializeFromByteArray(byteArray, index);
            index += ObjectSpaceObjectStreamHeader.totalSize;

            objectSpaceObjectStreamOfOIDs.Body = new CompactID[objectSpaceObjectStreamOfOIDs.Header.Count];
            for (var i = 0; i < objectSpaceObjectStreamOfOIDs.Header.Count; i++)
            {
                var compactID = CompactIDParser.DoDeserializeFromByteArray(byteArray, startIndex);
                objectSpaceObjectStreamOfOIDs.Body[i] = compactID;
                index += CompactID.totalSize;
            }

            return objectSpaceObjectStreamOfOIDs;
        }
    }
}
