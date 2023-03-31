namespace OneNoteFile.Structure.Other.Property
{
    internal class TwoBytesOfData : IProperty
    {
        internal byte[] Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            Data = new byte[2] { byteArray[startIndex], byteArray[startIndex + 1] };

            return 2;
        }
    }
}
