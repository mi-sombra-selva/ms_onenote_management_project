using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class OneByteOfDataParser : PropertyParser
    {
        internal override OneByteOfData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var oneByteOfData = new OneByteOfData();
            oneByteOfData.Data = byteArray[startIndex];
            return oneByteOfData;
        }
    }
}
