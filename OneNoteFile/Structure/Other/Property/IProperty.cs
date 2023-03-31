namespace OneNoteFile.Structure.Other.Property
{
    internal interface IProperty
    {
        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex);
    }
}
