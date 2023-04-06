using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class FourBytesOfDataParser : PropertyParser
    {
        internal override FourBytesOfData DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var fourBytesOfData = new FourBytesOfData();
            fourBytesOfData.Data = reader.ReadBytes(startIndex, 4);
            return fourBytesOfData;
        }
    }
}
