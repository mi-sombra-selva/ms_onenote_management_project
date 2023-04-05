using BitManipulator;
using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class CompactIDParser
    {
        public static CompactID DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var compactID = new CompactID();
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                compactID.N = bitReader.ReadUInt32(8);
                compactID.GuidIndex = bitReader.ReadUInt32(24);
            }
            return compactID;
        }
    }
}
