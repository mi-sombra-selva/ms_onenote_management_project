using BitManipulator;

namespace OneNoteFile.Types
{
    internal class CompactID
    {
        public uint N { get; set; }

        public uint GuidIndex { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                N = bitReader.ReadUInt32(8);
                GuidIndex = bitReader.ReadUInt32(24);
                return 4;
            }
        }
    }
}
