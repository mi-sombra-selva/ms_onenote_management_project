using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class OneByteOfDataParser : PropertyParser
    {
        internal override OneByteOfData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var oneByteOfData = new OneByteOfData();
            oneByteOfData.Data = reader.ReadByteFromPosition(startIndex);
            return oneByteOfData;
        }
    }
}
