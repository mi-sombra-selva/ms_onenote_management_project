using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class ArrayNumberParser : PropertyParser
    {
        internal override ArrayNumber DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var arrayNumber = new ArrayNumber();
            arrayNumber.Number = reader.ReadUInt32FromPosition(startIndex);
            return arrayNumber;
        }
    }
}
