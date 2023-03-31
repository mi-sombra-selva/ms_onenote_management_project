using BitManipulator;

namespace OneNoteFile.Structure.Other.Property
{
    internal class PropertyID
    {
        internal uint Id { get; set; }
        internal uint Type { get; set; }
        internal int BoolValue { get; set; }
        internal int Value { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            using (var bitReader = new BitReader(byteArray, startIndex))
            {
                Id = bitReader.ReadUInt32(26);
                Type = bitReader.ReadUInt32(5);
                BoolValue = bitReader.ReadInt32(1);
                Value = BitConverter.ToInt32(byteArray, startIndex);
                return 4;
            }
        }
    }
}
