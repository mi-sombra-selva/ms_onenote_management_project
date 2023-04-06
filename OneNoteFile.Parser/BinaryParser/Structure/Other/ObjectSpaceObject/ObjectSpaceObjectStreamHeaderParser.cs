using BitManipulator;
using OneNoteFile.Model.Structure.Other.ObjectSpaceObject;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamHeaderParser
    {
        internal static ObjectSpaceObjectStreamHeader DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var objectSpaceObjectStreamHeader = new ObjectSpaceObjectStreamHeader();
            using (var bitReader = new BitReader(reader, startIndex))
            {
                objectSpaceObjectStreamHeader.Count = bitReader.ReadUInt32(24);
                objectSpaceObjectStreamHeader.Reserved = bitReader.ReadInt32(6);
                objectSpaceObjectStreamHeader.ExtendedStreamsPresent = bitReader.ReadInt32(1);
                objectSpaceObjectStreamHeader.OsidStreamNotPresent = bitReader.ReadInt32(1);
            }
            return objectSpaceObjectStreamHeader;
        }
    }
}
