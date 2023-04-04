using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PrtFourBytesOfLengthFollowedByDataParser : PropertyParser
    {
        internal override PrtFourBytesOfLengthFollowedByData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var prtFourBytesOfLengthFollowedByData = new PrtFourBytesOfLengthFollowedByData();
            var index = startIndex;
            prtFourBytesOfLengthFollowedByData.CB = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            prtFourBytesOfLengthFollowedByData.Data = new byte[prtFourBytesOfLengthFollowedByData.CB];
            Array.Copy(byteArray, index, prtFourBytesOfLengthFollowedByData.Data, 0, prtFourBytesOfLengthFollowedByData.CB);
            index += (int)prtFourBytesOfLengthFollowedByData.CB;

            return prtFourBytesOfLengthFollowedByData;
        }
    }
}
