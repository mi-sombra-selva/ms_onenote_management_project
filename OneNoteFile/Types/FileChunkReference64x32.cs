namespace OneNoteFile.Types
{
    internal class FileChunkReference64x32 : FileChunkReference
    {
        internal ulong Stp { get; set; }

        internal uint Cb { get; set; }

        internal override int DoDeserializeFromByteArray(byte[] byteArray, int startIndex)
        {
            var index = startIndex;
            Stp = BitConverter.ToUInt64(byteArray, index);
            index += 8;
            Cb = BitConverter.ToUInt32(byteArray, index);
            index += 4;

            return index - startIndex;
        }

        internal override bool IsfcrNil()
        {
            return Stp == ulong.MaxValue && Cb == uint.MinValue;
        }

        internal override bool IsfcrZero()
        {
            return Stp == ulong.MinValue && Cb == uint.MinValue;
        }
    }
}
