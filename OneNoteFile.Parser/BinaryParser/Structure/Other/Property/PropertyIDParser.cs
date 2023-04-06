using BitManipulator;
using OneNoteFile.Model.Structure.Other.Property;

namespace OneNoteFile.Parser.BinaryParser.Structure.Other.Property
{
    internal class PropertyIDParser
    {
        internal static PropertyID DoDeserializeFromByteArray(BinaryReader reader, int startIndex)
        {
            var propertyID = new PropertyID();
            using (var bitReader = new BitReader(reader, startIndex))
            {
                propertyID.Id = bitReader.ReadUInt32(26);
                propertyID.Type = bitReader.ReadUInt32(5);
                propertyID.BoolValue = bitReader.ReadInt32(1);
                propertyID.Value = reader.ReadInt32FromPosition(startIndex);
            }
            return propertyID;
        }
    }
}
