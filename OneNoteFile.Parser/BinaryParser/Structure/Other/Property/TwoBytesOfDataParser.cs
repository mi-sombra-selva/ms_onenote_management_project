using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class TwoBytesOfDataParser : PropertyParser
    {
        internal override TwoBytesOfData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var twoBytesOfData = new TwoBytesOfData();
            twoBytesOfData.Data = new byte[2] { byteArray[startIndex], byteArray[startIndex + 1] };
            return twoBytesOfData;
        }
    }
}
