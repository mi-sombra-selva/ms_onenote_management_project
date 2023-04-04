using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class FourBytesOfDataParser : PropertyParser
    {
        internal override FourBytesOfData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var fourBytesOfData = new FourBytesOfData();
            fourBytesOfData.Data = new byte[4];
            Array.Copy(byteArray, startIndex, fourBytesOfData.Data, 0, 4);
            return fourBytesOfData;
        }
    }
}
