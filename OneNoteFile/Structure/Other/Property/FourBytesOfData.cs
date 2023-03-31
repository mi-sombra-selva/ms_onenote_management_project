namespace OneNoteFile.Structure.Other.Property
{
    internal class FourBytesOfData : IProperty
    {
        internal byte[] Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            Data = new byte[4];
            Array.Copy(byteArray, startIndex, Data, 0, 4);

            return 4;
        }
    }
}
