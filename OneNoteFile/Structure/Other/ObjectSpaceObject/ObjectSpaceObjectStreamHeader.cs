using BitManipulator;

namespace OneNoteFile.Structure.Other.ObjectSpaceObject
{
    internal class ObjectSpaceObjectStreamHeader
    {
        internal uint Count { get; set; }
        internal int Reserved { get; set; }
        internal int ExtendedStreamsPresent { get; set; }
        internal int OsidStreamNotPresent { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                Count = bitReader.ReadUInt32(24);
                Reserved = bitReader.ReadInt32(6);
                ExtendedStreamsPresent = bitReader.ReadInt32(1);
                OsidStreamNotPresent = bitReader.ReadInt32(1);
                return 4;
            }
        }
    }
}
