using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class TwoBytesOfDataParser : PropertyParser
    {
        internal override TwoBytesOfData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var twoBytesOfData = new TwoBytesOfData();
            twoBytesOfData.Data = reader.ReadBytes(startIndex, 2);
            return twoBytesOfData;
        }
    }
}
