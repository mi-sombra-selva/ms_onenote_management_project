using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PrtFourBytesOfLengthFollowedByDataParser : PropertyParser
    {
        internal override PrtFourBytesOfLengthFollowedByData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var prtFourBytesOfLengthFollowedByData = new PrtFourBytesOfLengthFollowedByData();
            var index = startIndex;
            prtFourBytesOfLengthFollowedByData.CB = reader.ReadUInt32FromPosition(index);
            index += 4;
            prtFourBytesOfLengthFollowedByData.Data = reader.ReadBytes(index, (int)prtFourBytesOfLengthFollowedByData.CB);
            return prtFourBytesOfLengthFollowedByData;
        }
    }
}
