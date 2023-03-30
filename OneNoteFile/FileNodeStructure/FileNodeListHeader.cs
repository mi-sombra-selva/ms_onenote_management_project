namespace OneNoteFile.FileNodeStructure
{
    internal class FileNodeListHeader
    {
        internal ulong uintMagic { get; set; }
        internal uint FileNodeListID { get; set; }
        internal uint nFragmentSequence { get; set; }

        internal int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            uintMagic = BitConverter.ToUInt64(byteArray, index);
            index += 8;
            FileNodeListID = BitConverter.ToUInt32(byteArray, index);
            index += 4;
            nFragmentSequence = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }
    }
}
