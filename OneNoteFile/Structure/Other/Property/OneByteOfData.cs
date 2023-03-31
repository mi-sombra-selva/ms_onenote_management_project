namespace OneNoteFile.Structure.Other.Property
{
    internal class OneByteOfData : IProperty
    {
        internal byte Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            Data = byteArray[startIndex];
            return 1;
        }
    }
}
