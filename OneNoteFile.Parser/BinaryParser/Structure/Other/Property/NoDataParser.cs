using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class NoDataParser : PropertyParser
    {
        internal override NoData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            return new NoData();
        }
    }
}
