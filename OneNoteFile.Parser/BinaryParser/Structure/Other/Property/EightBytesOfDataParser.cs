using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class EightBytesOfDataParser : PropertyParser
    {
        internal override EightBytesOfData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var eightBytesOfData = new EightBytesOfData();
            eightBytesOfData.Data = reader.ReadBytes(startIndex, 8);
            return eightBytesOfData;
        }
    }
}
