namespace OneNoteFile.Structure.Other.Property
{
    internal class EightBytesOfData : IProperty
    {
        internal byte[] Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            Data = new byte[8];
            Array.Copy(byteArray, startIndex, Data, 0, 8);
            return 8;
        }
    }
}
