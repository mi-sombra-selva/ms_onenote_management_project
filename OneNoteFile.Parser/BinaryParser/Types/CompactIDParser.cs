using BitManipulator;
using OneNoteFile.Model.Types;

namespace OneNoteFile.Parser.BinaryParser.Types
{
    internal class CompactIDParser
    {
        public static CompactID DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var compactID = new CompactID();
            using (var bitReader = new BitReader(reader, startIndex))
            {
                compactID.N = bitReader.ReadUInt32(8);
                compactID.GuidIndex = bitReader.ReadUInt32(24);
            }
            return compactID;
        }
    }
}
