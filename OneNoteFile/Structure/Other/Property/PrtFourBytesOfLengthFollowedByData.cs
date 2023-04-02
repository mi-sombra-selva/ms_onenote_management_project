namespace OneNoteFile.Structure.Other.Property
{
    internal class PrtFourBytesOfLengthFollowedByData : IProperty
    {
        internal uint CB { get; set; }
        internal byte[] Data { get; set; }

        public int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            CB = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            Data = new byte[CB];
            Array.Copy(byteArray, index, Data, 0, CB);
            index += (int)CB;

            return index - startIndex;
        }
    }
}
