using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class ArrayNumberParser : PropertyParser
    {
        internal override ArrayNumber DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var arrayNumber = new ArrayNumber();
            arrayNumber.Number = BitConverter.ToUInt32(byteArray, startIndex);
            return arrayNumber;
        }
    }
}
