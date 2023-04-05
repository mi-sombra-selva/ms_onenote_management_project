using BitManipulator;
using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PropertyIDParser
    {
        internal static PropertyID DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var propertyID = new PropertyID();
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                propertyID.Id = bitReader.ReadUInt32(26);
                propertyID.Type = bitReader.ReadUInt32(5);
                propertyID.BoolValue = bitReader.ReadInt32(1);
                propertyID.Value = BitConverter.ToInt32(byteArray, startIndex);
            }
            return propertyID;
        }
    }
}
