namespace OneNoteFile.Structure.Other.Property
{
    internal class ArrayNumber : IProperty
    {
        internal uint Number { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            Number = BitConverter.ToUInt32(byteArray, startIndex);
            return 4;
        }
    }
}
