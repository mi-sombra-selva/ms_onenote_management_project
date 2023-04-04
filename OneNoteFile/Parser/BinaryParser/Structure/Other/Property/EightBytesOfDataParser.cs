using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class EightBytesOfDataParser : PropertyParser
    {
        internal override EightBytesOfData DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var eightBytesOfData = new EightBytesOfData();
            eightBytesOfData.Data = new byte[8];
            Array.Copy(byteArray, startIndex, eightBytesOfData.Data, 0, 8);
            return eightBytesOfData;
        }
    }
}
